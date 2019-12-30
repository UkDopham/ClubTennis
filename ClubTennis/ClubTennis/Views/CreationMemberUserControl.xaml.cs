using ClubTennis.Models;
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
    /// Logique d'interaction pour CreationMemberUserControl.xaml
    /// </summary>
    public partial class CreationMemberUserControl : UserControl
    {

        public CreationMemberUserControl()
        {
            InitializeComponent();
        }
        public bool IsAllFill()
        {
            return !string.IsNullOrEmpty(PrenomTextBox.Text) &&
                !string.IsNullOrEmpty(NomTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text) &&
                !string.IsNullOrEmpty(AdressTextBox.Text);
        }
        public Member GetMember()
        {
            return ClassementComboBox.SelectedIndex == 0 ? new Member(PrenomTextBox.Text,
                NomTextBox.Text,
                PhoneTextBox.Text,
               (GenderEnum)GenreComboBox.SelectedIndex,
               AdressTextBox.Text,
               (bool)PaymentCheckBox.IsChecked) :

               new Member(PrenomTextBox.Text,
                NomTextBox.Text,
                PhoneTextBox.Text,
               (GenderEnum)GenreComboBox.SelectedIndex,
               AdressTextBox.Text,
               (bool)PaymentCheckBox.IsChecked,
               ClassementComboBox.SelectedIndex.ToString());//TODO ENUM classement
        }
    }
}
