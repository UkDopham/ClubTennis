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
    /// Logique d'interaction pour MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        private string _username;

        public string Username
        {
            get
            {
                return this._username;
            }
        }
        public MenuUserControl(Data data, User user)
        {
            InitializeComponent();
            this._username = user.Username;
            SideMenuGrid.Visibility = Visibility.Hidden;
            DataContext = new MemberUserControl();
        }

        private void BorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.DragMove();
        }

        private void FermerButtonClick(object sender, RoutedEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.Close();
        }

        private void OnOffButtonClick(object sender, RoutedEventArgs e)
        {
            SideMenuGrid.Visibility = SideMenuGrid.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
