using ClubTennis.Models;
using ClubTennis.ViewModels;
using ClubTennis.Views.Interfaces;
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
    /// Logique d'interaction pour MemberUserControl.xaml
    /// </summary>
    public partial class MemberUserControl : UserControl, ISave
    {
        private MemberVM _memberVM;
        private Save _save;

        public MemberVM MemberVM
        {
            get
            {
                return this._memberVM;
            }
        }
        public MemberUserControl(Save save)
        {
            this._memberVM = new MemberVM();
            this._save = save;
            InitializeComponent();
            DataContext = this._memberVM;
        }

        public Save Save => this._save;

        private void EmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            this._memberVM.SelectedUserControl = new EmployeeListUserControl();
        }

        private void MemberButtonClick(object sender, RoutedEventArgs e)
        {
            this._memberVM.SelectedUserControl = new MemberListUserControl(this._save); 
        }
    }
}
