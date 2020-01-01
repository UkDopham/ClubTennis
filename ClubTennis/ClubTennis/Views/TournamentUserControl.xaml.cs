using ClubTennis.Models;
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
    /// Logique d'interaction pour TournamentUserControl.xaml
    /// </summary>
    public partial class TournamentUserControl : UserControl, ISave
    {
        private Save _save;
        public TournamentUserControl(Save save)
        {
            this._save = save;
            InitializeComponent();
        }

        public Save Save
        {
            get
            {
                return this._save;
            }
            set
            {
                this._save = value;
            }
        }
    }
}
