using ClubTennis.Models;
using ClubTennis.Models.Filters;
using ClubTennis.ViewModels;
using ClubTennis.Views.Interfaces;
using System;
using System.Collections.Generic;
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
    public partial class MemberUserControl : UserControl, ISave
    {
        private MemberVM _memberVM;
        private Save _save;
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
            this._memberVM = new MemberVM();

            this._employeeSelected = false;
            this._memberSelected = false;

            this._peoples = save.Peoples;
            this._save = save;
            this._activeFilters = new List<Filter>();
            InitializeComponent();
            DataContext = this._memberVM;
            this._alfabetSorted = false;
            this._classementSorted = false;
        }

        public Save Save => this._save;

        private void EmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            this._employeeSelected = !this._employeeSelected;

            EmployeeButton.Background = this._employeeSelected ? SolidColorBrushHelper.DarkGreen() : SolidColorBrushHelper.Green();

            //Reset coulours des autres buttons
            MemberButton.Background = SolidColorBrushHelper.Green();
            this._memberSelected = false;

            this._memberVM.SelectedUserControl = new EmployeeListUserControl();
        }

        private void MemberButtonClick(object sender, RoutedEventArgs e)
        {
            this._memberSelected = !this._memberSelected;

            MemberButton.Background = this._memberSelected ? SolidColorBrushHelper.DarkGreen() : SolidColorBrushHelper.Green();
            
            //Reset coulours des autres buttons
            EmployeeButton.Background = SolidColorBrushHelper.Green();
            this._employeeSelected = false;

            this._memberVM.SelectedUserControl = new MemberListUserControl(this._save.Peoples); 
        }
        /// <summary>
        /// Effectue tous les tris activés sur la liste de personne
        /// </summary>
        /// <returns></returns>
        private List<People> Sort()
        {
            List<People> peoples = this._peoples;
            foreach(Filter filter in this._activeFilters)
            {
                peoples = filter.Order(peoples);
            }
            return peoples;
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
                this._activeFilters.Add(filter); //FILTER PATTERN
            }
            else
            {
                List<AlfabetFilter> tmp = this._activeFilters.OfType<AlfabetFilter>().ToList();
                tmp.ForEach(x => this._activeFilters.Remove(x));
            }

            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
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
                this._activeFilters.Add(filter);
            }
            else
            {
                List<CompetitionFilter> tmp = this._activeFilters.OfType<CompetitionFilter>().ToList();
                tmp.ForEach(x => this._activeFilters.Remove(x));
            }


            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
        }
        /// <summary>
        /// Filtre sur le genre du membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenderComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all / 1 man / 2 woman / 3 other


            switch (GenderComboBox.SelectedIndex)
            {
                case 0:
                    List<GenderFilterMale> males = this._activeFilters.OfType<GenderFilterMale>().ToList();
                    males.ForEach(x => this._activeFilters.Remove(x));

                    List<GenderFilterWoman> women = this._activeFilters.OfType<GenderFilterWoman>().ToList();
                    women.ForEach(x => this._activeFilters.Remove(x));

                    List<GenderFilterOther> others = this._activeFilters.OfType<GenderFilterOther>().ToList();
                    others.ForEach(x => this._activeFilters.Remove(x));
                    break;

                case 1:
                    GenderFilterMale male = new GenderFilterMale();
                    this._activeFilters.Add(male);
                    break;

                case 2:
                    GenderFilterWoman woman = new GenderFilterWoman();
                    this._activeFilters.Add(woman);
                    break;

                case 3:
                    GenderFilterOther other = new GenderFilterOther();
                    this._activeFilters.Add(other);
                    break;
            }

            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
        }
        /// <summary>
        /// Filtre sur l'etat du payment du membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all / 1 a jour / 2 retard

            switch (PaymentComboBox.SelectedIndex)
            {
                case 0:
                    List<LateFilter> lates = this._activeFilters.OfType<LateFilter>().ToList();
                    lates.ForEach(x => this._activeFilters.Remove(x));

                    List<PaidFilter> paids = this._activeFilters.OfType<PaidFilter>().ToList();
                    paids.ForEach(x => this._activeFilters.Remove(x));
                    break;

                case 1:
                    PaidFilter paid = new PaidFilter();
                    this._activeFilters.Add(paid);
                    break;

                case 2:
                    LateFilter late = new LateFilter();
                    this._activeFilters.Add(late);
                    break;
            }

            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
        }
        /// <summary>
        /// Filtre sur le fait de participé aux compét ou pas d'un membre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoisirComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 all /1 loisir / 2 Compétition


            switch (LoisirComboBox.SelectedIndex)
            {
                case 0:
                    List<LoisirFilter> loisirs = this._activeFilters.OfType<LoisirFilter>().ToList();
                    loisirs.ForEach(x => this._activeFilters.Remove(x));

                    List<DoCompetitonFilter> doCompetition = this._activeFilters.OfType<DoCompetitonFilter>().ToList();
                    doCompetition.ForEach(x => this._activeFilters.Remove(x));
                    break;

                case 1:
                    LoisirFilter loisir = new LoisirFilter();
                    this._activeFilters.Add(loisir);
                    break;

                case 2:
                    DoCompetitonFilter doCompetiton = new DoCompetitonFilter();
                    this._activeFilters.Add(doCompetiton);
                    break;
            }


            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text == null)
                SearchTextBox.Text = string.Empty;

            SearchFilter filter = new SearchFilter(SearchTextBox.Text);

            this._activeFilters.Add(filter);
            this._memberVM.SelectedUserControl = new MemberListUserControl(Sort());
            this._activeFilters.Remove(filter);
        }

        private void NewButtonClick(object sender, RoutedEventArgs e)
        {
            CreationWindows newWindows = new CreationWindows(this._save)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            newWindows.ShowDialog();
            this._save = newWindows.Save;
            this._memberVM.SelectedUserControl =new MemberListUserControl(Sort());
        }
    }
}
