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
    /// Logique d'interaction pour LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private LoginVM _loginVM; 
        public LoginUserControl()
        {
            this._loginVM = new LoginVM();
            InitializeComponent();
            RememberInitialization();
        }

        private void RememberInitialization()
        {
            if (!string.IsNullOrEmpty(this._loginVM.Data.Remember))
            {
                rememberCheckBox.IsChecked = true;
                UsernameTextBox.Text = this._loginVM.Data.Remember;
            }
        }
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {           
            if (this._loginVM.IsCorrectID(UsernameTextBox.Text, PasswordBox.Password))
            {
                Window fenetre = Window.GetWindow(this);

                Save save = this._loginVM.SaveFromUser(UsernameTextBox.Text);
                
                if (save != null)
                {
                    fenetre.DataContext = new MenuUserControl(save, this._loginVM.User);
                    this._loginVM.Remember((bool)rememberCheckBox.IsChecked, UsernameTextBox.Text);
                }
                else
                {
                    Redden();
                }
                
            }
            else
            {
                Redden();
            }
        }

        private void Redden()
        {
            UsernameTextBox.Foreground = new SolidColorBrush(Colors.Red);
            PasswordBox.Foreground = new SolidColorBrush(Colors.Red);
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
