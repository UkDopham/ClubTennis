using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class User
    {
        private Guid _guid;
        private string _username;
        private string _password;
        private People _people;

        public User(string username, string password, People people)
        {
            this._guid = Guid.NewGuid();
            this._username = username;
            this._password = password;
            this._people = people;
        }
    }
}
