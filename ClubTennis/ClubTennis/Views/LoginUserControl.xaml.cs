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
    /// Logique d'interaction pour LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private Data _data;
        public LoginUserControl()
        {
            InitializeComponent();
            this._data = new Data();
            RememberInitialization();
        }

        private void RememberInitialization()
        {
            this._data.LoadRemember();
            if (!string.IsNullOrEmpty(this._data.Remember))
            {
                rememberCheckBox.IsChecked = true;
            }
        }
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {           
            this._data.LoadID();
            
            MessageBox.Show(IsCorrectID().ToString());
            if(IsCorrectID())
            {
                
            }
        }

        public bool IsCorrectID()
        {
            bool isCorrect = false;

            if (this._data.Users != null)
            {
                User user = this._data.Users.FirstOrDefault(x => x.Username == UsernameTextBox.Text && x.Password == PasswordBox.Password);

                if (user != null)
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
    }
}
