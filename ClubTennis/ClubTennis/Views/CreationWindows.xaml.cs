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
using System.Windows.Shapes;

namespace ClubTennis.Views
{
    /// <summary>
    /// Logique d'interaction pour CreationWindows.xaml
    /// </summary>
    public partial class CreationWindows : Window
    {
        private CreationVM _creationVM;
        private bool _isMember;
        private Save _save;

        public Save Save
        {
            get
            {
                return this._save;
            }
        }
        public CreationWindows(Save save)
        {
            this._save = save;
            this._creationVM = new CreationVM();
            this._creationVM.CreationUserControl = new CreationMemberUserControl();
            DataContext = this._creationVM;
            this._isMember = true;
            InitializeComponent();
        }

        private void BorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.DragMove();
        }

        private void TitleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._isMember)
            {
                CreationMemberUserControl creationMemberUserControl = (CreationMemberUserControl)this._creationVM.CreationUserControl;
                if(creationMemberUserControl.IsAllFill())
                {
                    Member member = creationMemberUserControl.GetMember();
                    Data data = new Data();
                    data.Load();
                    this._save.Peoples.Add(member);
                    data.Saves.Add(this._save);
                    data.Write();
                    CloseWindows();
                }
            }
        }

        private void CloseWindows()
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }
    }
}
