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
        }
        public CreationMemberUserControl(Member member)
        {
            this._guid = member.Guid;
            InitializeComponent();
            PrenomTextBox.Text = member.FirstName;
            NomTextBox.Text = member.LastName;
            PhoneTextBox.Text = member.PhoneNumber;
            GenreComboBox.SelectedIndex = Convert.ToInt32(member.Gender) - 1;
            AdressTextBox.Text = member.Adress;
            PaymentCheckBox.IsChecked = member.HasPaid;
            ClassementComboBox.SelectedIndex = member.ClassementValue();
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
            if (Guid.Equals(this._guid, Guid.Empty)) //cas de nouveau membre
            {
                return ClassementComboBox.SelectedIndex == 0 ? new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                   (bool)PaymentCheckBox.IsChecked) :

                   new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                   (bool)PaymentCheckBox.IsChecked,
                   ClassementComboBox.SelectedIndex.ToString());//TODO ENUM classement
            }
            else
            {
                return ClassementComboBox.SelectedIndex == 0 ? new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                   (bool)PaymentCheckBox.IsChecked,
                   this._guid) :

                   new Member(PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                   (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                   AdressTextBox.Text,
                   (bool)PaymentCheckBox.IsChecked,
                   ClassementComboBox.SelectedIndex.ToString(),
                   this._guid);//TODO ENUM classement
            }
        }
    }
}
