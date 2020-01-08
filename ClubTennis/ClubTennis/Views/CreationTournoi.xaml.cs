using ClubTennis.Models;
using ClubTennis.ViewModels;
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
    /// Logique d'interaction pour CreationTournoi.xaml
    /// </summary>
    public partial class CreationTournoi : Page
    {
        public CreationTournoi()
        {
            InitializeComponent();
        }
        public Competition GetCompetition()
        {
            ClassementComboBox.ItemsSource = ((IEnumerable<ClassementEnum>)Enum.GetValues(typeof(ClassementEnum))).Select(x => EnumHelper.GetDescription(x));
            ClassementComboBox.SelectedIndex = 0;
            SexeCombobox.ItemsSource = ((IEnumerable<GenderEnum>)Enum.GetValues(typeof(GenderEnum))).Select(x => EnumHelper.GetDescription(x));
            SexeCombobox.SelectedIndex = 0;
            NiveauComboBox.ItemsSource = ((IEnumerable<LevelEnum>)Enum.GetValues(typeof(LevelEnum))).Select(x => EnumHelper.GetDescription(x));
            NiveauComboBox.SelectedIndex = 0;
            TypeComboBox.ItemsSource = ((IEnumerable<CompetitionTypeEnum>)Enum.GetValues(typeof(CompetitionTypeEnum))).Select(x => EnumHelper.GetDescription(x));
            TypeComboBox.SelectedIndex = 0;

            int duree = Convert.ToInt32(DureeTextBox.Text);
            return new Competition(NomTextBox.Text,
                (ClassementEnum)(ClassementComboBox.SelectedIndex),
                null,
                0,
                duree,
                (DateTime)DatePick.SelectedDate,
                (CompetitionTypeEnum)TypeComboBox.SelectedIndex,
                CompetitionAgeTypeEnum.all,
                (GenderEnum)(SexeCombobox.SelectedIndex + 1));
        }

        public bool IsAllFill()
        {
            return !string.IsNullOrEmpty(NomTextBox.Text) &&
                !string.IsNullOrEmpty(VilleTextBox.Text) &&
                DatePick.SelectedDate != null &&
                ClassementComboBox.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(DureeTextBox.Text) &&
                TypeComboBox.SelectedIndex != -1;
        }

        private void ValiderCompete_Click(object sender, RoutedEventArgs e)
        {
            CreationTournoi tournoi = new CreationTournoi();
            if (tournoi.IsAllFill())
            {
                //On l'ajoute en mémoire ? On l'affiche che po où
            }
            
        }

        //return new Member(PrenomTextBox.Text,
        //            NomTextBox.Text,
        //            PhoneTextBox.Text,
        //           (GenderEnum)(GenreComboBox.SelectedIndex + 1),
        //           AdressTextBox.Text,
        //            (DateTime) BirthDatePicker.SelectedDate,
        //           (bool) PaymentCheckBox.IsChecked,
        //           (ClassementEnum) ClassementComboBox.SelectedIndex,
        //           this._guid);//TODO ENUM classement

        //    CreationMemberUserControl creationMemberUserControl = (CreationMemberUserControl)this._creationVM.CreationUserControl;
        //                if (creationMemberUserControl.IsAllFill())
        //                {
        //                    Member member = creationMemberUserControl.GetMember();
        //                    Data data = new Data();
        //                    data.Load(); //on reload pour enrengistrer car pb de data binding
        //                    this._creationVM.Save.Peoples.Add(member);
        //                    data.AddSave(this._creationVM.Save);
        //                    data.Write();
        //                    CloseWindows();
        //}
    }
}
