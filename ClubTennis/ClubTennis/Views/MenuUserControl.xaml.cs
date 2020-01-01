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
    /// Logique d'interaction pour MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        private MenuVM _menu;
        private List<Button> _buttons;

        private MemberUserControl _memberUserControl;

        public MemberUserControl MemberUserControl
        {
            get
            {
                return this._memberUserControl;
            }
        }
        
        public MenuUserControl(Save save, User user)
        {
            InitializeComponent();
            InitializationButtons();
            this._menu = new MenuVM(save, user);
            SideMenuGrid.Visibility = Visibility.Hidden;

            DataContext = new MemberUserControl(this._menu.Save);
            MemberButton.Background = SolidColorBrushHelper.DarkGreen();
        }

        private void InitializationButtons()
        {
            this._buttons = new List<Button>();
            this._buttons.Add(MemberButton);
            this._buttons.Add(TournamentButton);
        }

        private void UnselectedButtonsColorization(Button button)
        {
            List<Button> unselectedButtons = this._buttons.Where(x => !x.Equals(button)).ToList();
            unselectedButtons.ForEach(x => x.Background = new SolidColorBrush(Colors.White));
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

        private void MemberButtonClick(object sender, RoutedEventArgs e)
        {
            this._memberUserControl = new MemberUserControl(this._menu.Save);
            DataContext = this._memberUserControl;

            UnselectedButtonsColorization(MemberButton);
            MemberButton.Background = SolidColorBrushHelper.DarkGreen(); 
        }

        private void TournamentButtonClick(object sender, RoutedEventArgs e)
        {
            DataContext = new TournamentUserControl(this._menu.Save);

            UnselectedButtonsColorization(TournamentButton);
            TournamentButton.Background = SolidColorBrushHelper.DarkGreen();
        }
    }
}
