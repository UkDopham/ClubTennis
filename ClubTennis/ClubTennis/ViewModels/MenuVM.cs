using ClubTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.ViewModels
{
    public class MenuVM : ObservableObject
    {
        private User _user;
        private Save _save;

        public User User
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
                OnPropertyChanged("User");
            }
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
                OnPropertyChanged("Save");
            }
        }
        public MenuVM(Save save, User user)
        {
            this._user = user;
            this._save = save;
        }
    }
}
