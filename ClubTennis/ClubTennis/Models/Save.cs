using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Save
    {
        private const string PATH = "Data/"; 
        private List<People> _peoples;
        private Club _club;
        private List<User> _users; //Liste des utilisateurs qui ont acces aux données

        public List<People> Peoples
        {
            get
            {
                return this._peoples;
            }
            set
            {
                this._peoples = value;
            }
        }
        public Club Club
        {
            get
            {
                return this._club;
            }
            set
            {
                this._club = value;
            }
        }
        public List<User> Users
        {
            get
            {
                return this._users;
            }
            set
            {
                this._users = value;
            }
        }
        public string GetPath()
        {
            return $"{PATH}{this._club.Name}{ExtensionHelper.GetExtension()}"; //CUSTOM extension 
        }

    }
}
