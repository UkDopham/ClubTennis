using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClubTennis.ViewModels
{
    public class CreationVM : ObservableObject
    {
        private UserControl _creationUserControl;

        public UserControl CreationUserControl
        {
            get
            {
                return this._creationUserControl;
            }
            set
            {
                this._creationUserControl = value;
                OnPropertyChanged("CreationUserControl");
            }
        }
    }
}
