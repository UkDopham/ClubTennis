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
        private Guid _guid;

        public Guid Guid
        {
            get
            {
                return this._guid;
            }
        }
        public CreationMemberUserControl()
        {
            InitializeComponent();
            ClassementComboBox.ItemsSource = Enum.GetValues(typeof(ClassementEnum));
            ClassementComboBox.SelectedIndex = 0;
        }
        public CreationMemberUserControl(Member member)
        {
            this._guid = member.Guid;
            InitializeComponent();
            ClassementComboBox.ItemsSource = Enum.GetValues(typeof(ClassementEnum));
            PrenomTextBox.Text = member.FirstName;
            NomTextBox.Text = member.LastName;
            PhoneTextBox.Text = member.PhoneNumber;
            GenreComboBox.SelectedIndex = Convert.ToInt32(member.Gender) - 1; //-1 car dans l'enum la premiere valeur est "tout"
            AdressTextBox.Text = member.Adress;
            PaymentCheckBox.IsChecked = member.HasPaid;
            ClassementComboBox.SelectedIndex = Convert.ToInt32(member.Classement);
            BirthDatePicker.SelectedDate = member.Birthdate;
        }

        public bool IsAllFill()
        {
            return !string.IsNullOrEmpty(PrenomTextBox.Text) &&
                !string.IsNullOrEmpty(NomTextBox.Text) &&
                !string.IsNullOrEmpty(AdressTextBox.Text) &&
                BirthDatePicker.SelectedDate != null;
        }
        public Member GetMember()
        {
            if (Guid.Equals(this._guid, Guid.Empty)) //cas de nouveau membre
            {
                return new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                    (DateTime)BirthDatePicker.SelectedDate,
                   (bool)PaymentCheckBox.IsChecked,
                   (ClassementEnum)ClassementComboBox.SelectedIndex);//TODO ENUM classement
            }
            else
            {
                return new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                    (DateTime)BirthDatePicker.SelectedDate,
                   (bool)PaymentCheckBox.IsChecked,
                   (ClassementEnum)ClassementComboBox.SelectedIndex,
                   this._guid);//TODO ENUM classement
            }
        }
    }
}
