using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class User
    {
        private string _username;
        private string _password;
        private People _people;

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }
        public User(string username, string password, People people)
        {
            this._username = username;
            this._password = password;
            this._people = people;
        }

        public User(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

    }
}
