using ClubTennis.Models;
using ClubTennis.Models.Filters;
using ClubTennis.ViewModels;
using ClubTennis.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClubTennis.Views
{
    /// <summary>
    /// Logique d'interaction pour MemberUserControl.xaml
    /// </summary>
    public partial class MemberUserControl : UserControl
    {
        private MemberVM _memberVM;
        private List<People> _peoples;

        private bool _memberSelected;
        private bool _employeeSelected;
        private bool _alfabetSorted;
        private bool _classementSorted;

        private List<Filter> _activeFilters; //Stockage des filtres actifs
        public MemberVM MemberVM
        {
            get
            {
                return this._memberVM;
            }
        }
        public MemberUserControl(Save save)
        {
            this._memberVM = new MemberVM(save);

            this._employeeSelected = false;
            this._memberSelected = true;
            this._alfabetSorted = false;
            this._classementSorted = false;
            this._activeFilters = new List<Filter>();
            InitializeComponent();

            MemberButton.Background = this._memberSelected ? SolidColorBrushHelper.DarkGreen() : SolidColorBrushHelper.Green();

            DataContext = this._memberVM;
        }


        private void EmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            PaymentComboBox.Visibility = LoisirComboBox.Visibility = ClassementButton.Visibility = Visibility.Hidden;

            this._employeeSelected = !this._employeeSelected;

            EmployeeButton.Background = this._employeeSelected ? SolidColorBrushHelper.DarkGreen() : SolidColorBrushHelper.Green();

            //Reset coulours des autres buttons
            MemberButton.Background = SolidColorBrushHelper.Green();
            this._memberSelected = false;

            this._memberVM.SelectedUserControl = new EmployeeListUserControl(this._memberVM.Save.Peoples, this._memberVM.Save);
        }

        private void MemberButtonClick(object sender, RoutedEventArgs e)
        {
            PaymentComboBox.Visibility = LoisirComboBox.Visibility = ClassementButton.Visibility = Visibility.Visible;
            this._memberSelected = !this._memberSelected;

            MemberButton.Background = this._memberSelected ? SolidColorBrushHelper.DarkGreen() : SolidColorBrushHelper.Green();
            
            //Reset coulours des autres buttons
            EmployeeButton.Background = SolidColorBrushHelper.Green();
            this._employeeSelected = false;

            this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Save.Peoples, this._memberVM.Save); 
        }
        /// <summary>
        /// Filtre sur l'ordre alphabetique du nom des membres
        /// On utilise pour les filtres une list<Filter> ce qui permet de stocker tous les filtres actifs pour les cas ou l'on veut 
        /// pouvoir utiliser des filtres simultanéments
        /// pour effectué un filtre on ajoute une classe fille dans la liste activefilter
        /// pour reset le filtre on l'enleve de la liste
        /// a la fin de la methode on effectue tous les filtres actifs
        /// la variable bool permet de choisir le pattern en fonction des valeurs       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlfabetButtonClick(object sender, RoutedEventArgs e)
        {
            this._alfabetSorted = !this._alfabetSorted;

            AlfabetButton.Background = this._alfabetSorted ? SolidColorBrushHelper.Green() : SolidColorBrushHelper.Transparent();

            AlfabetFilter filter = new AlfabetFilter();

            if (this._alfabetSorted)
            {
                this._memberVM.AddFilter(filter);
            }
            else
            {
                this._memberVM.RemoveFilter(filter);
            }

            if (this._memberSelected)
            {
                this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
            else
            {
                this._memberVM.SelectedUserControl = new EmployeeListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
        }

        /// <summary>
        /// Filtre sur le classement des membres
        /// Même fonctionnement que pour celui alphabetique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassementButtonClick(object sender, RoutedEventArgs e)
        {
            this._classementSorted = !this._classementSorted;

            ClassementButton.Background = this._classementSorted ? SolidColorBrushHelper.Green() : SolidColorBrushHelper.Transparent();
            CompetitionFilter filter = new CompetitionFilter();

            if (this._classementSorted)
            {
                this._memberVM.AddFilter(filter);
            }
            else
            {
                this._memberVM.RemoveFilter(filter);
            }

            this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
        }
        /// <summary>
        /// Filtre sur le genre du membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenderComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all / 1 man / 2 woman / 3 other

            this._memberVM.RemoveFilter(new GenderFilterMale());
            this._memberVM.RemoveFilter(new GenderFilterWoman());
            this._memberVM.RemoveFilter(new GenderFilterOther());

            switch (GenderComboBox.SelectedIndex)
            {

                case 1:
                    GenderFilterMale male = new GenderFilterMale();
                    this._memberVM.AddFilter(male);
                    break;

                case 2:
                    GenderFilterWoman woman = new GenderFilterWoman();
                    this._memberVM.AddFilter(woman);
                    break;

                case 3:
                    GenderFilterOther other = new GenderFilterOther();
                    this._memberVM.AddFilter(other);
                    break;
            }

            if (this._memberSelected)
            {
                this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
            else
            {
                this._memberVM.SelectedUserControl = new EmployeeListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
        }
        /// <summary>
        /// Filtre sur l'etat du payment du membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all / 1 a jour / 2 retard

            this._memberVM.RemoveFilter(new LateFilter());
            this._memberVM.RemoveFilter(new PaidFilter());

            switch (PaymentComboBox.SelectedIndex)
            {
                case 1:
                    PaidFilter paid = new PaidFilter();
                    this._memberVM.AddFilter(paid);
                    break;

                case 2:
                    LateFilter late = new LateFilter();
                    this._memberVM.AddFilter(late);
                    break;
            }

            this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
        }
        /// <summary>
        /// Filtre sur le fait de participé aux compét ou pas d'un membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoisirComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all /1 loisir / 2 Compétition

            this._memberVM.RemoveFilter(new LoisirFilter());
            this._memberVM.RemoveFilter(new DoCompetitonFilter());

            switch (LoisirComboBox.SelectedIndex)
            {

                case 1:
                    LoisirFilter loisir = new LoisirFilter();
                    this._memberVM.AddFilter(loisir);
                    break;

                case 2:
                    DoCompetitonFilter doCompetiton = new DoCompetitonFilter();
                    this._memberVM.AddFilter(doCompetiton);
                    break;
            }


            this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text == null)
                SearchTextBox.Text = string.Empty;

            SearchFilter filter = new SearchFilter(SearchTextBox.Text);

            this._memberVM.AddFilter(filter);

            if (this._memberSelected)
            {
                this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
            else
            {
                this._memberVM.SelectedUserControl = new EmployeeListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }

            this._memberVM.RemoveFilter(filter);
        }

        private void NewButtonClick(object sender, RoutedEventArgs e)
        {
            CreationWindows newWindows = new CreationWindows(this._memberVM.Save) //on importe la sauvegarde pour la modifier dans la fonction
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            newWindows.ShowDialog();
            //this._memberVM.

            if (this._memberSelected)
            {
                this._memberVM.SelectedUserControl = new MemberListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
            else
            {
                this._memberVM.SelectedUserControl = new EmployeeListUserControl(this._memberVM.Sort(), this._memberVM.Save);
            }
        }
    }
}
