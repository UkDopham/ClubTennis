using ClubTennis.Models;
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
        private Save _save;
        private UserControl _creationUserControl;

        public Save Save
        {
            get
            {
                return this._save;
            }
            set
            {
                this._save = value;
                OnPropertyChanged("Save");
            }
        }
        public CreationVM(Save save)
        {
            this._save = save;
        }
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
