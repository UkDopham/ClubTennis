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
        private MenuUserControl _menuUserControl;
        private User _user;
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
                UsernameTextBox.Text = this._data.Remember;
            }
        }
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {           
            this._data.LoadID();
            if (IsCorrectID())
            {
                Window fenetre = Window.GetWindow(this);
                fenetre.DataContext = new MenuUserControl(this._data, this._user);

                this._data.Remember = (bool)rememberCheckBox.IsChecked ? UsernameTextBox.Text : string.Empty;
                this._data.WriteRemember();
            }
            else
            {
                UsernameTextBox.Foreground = new SolidColorBrush(Colors.Red);
                PasswordBox.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        public bool IsCorrectID()
        {
            bool isCorrect = false;

            if (this._data.Users != null)
            {
                this._user = this._data.Users.FirstOrDefault(x => x.Username == UsernameTextBox.Text && x.Password == PasswordBox.Password);

                if (this._user != null)
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Foreground = new SolidColorBrush(Colors.Black);
            PasswordBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void FermerButtonClick(object sender, RoutedEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.Close();
        }

        private void BorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.DragMove();
        }

    }
}
