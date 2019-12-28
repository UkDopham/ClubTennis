using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClubTennis.ViewModels
{
    public class MemberVM : ObservableObject
    {
        private UserControl _selectedUserControl;

        public UserControl SelectedUserControl
        {
            get
            {
                return this._selectedUserControl;
            }
            set
            {
                this._selectedUserControl = value;
                OnPropertyChanged("SelectedUserControl");
            }
        }
    }
}
