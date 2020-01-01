using ClubTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.ViewModels
{
    public class LoginVM
    {
        private Data _data;
        private User _user;

        public Data Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        public User User
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
            }
        }
        public LoginVM()
        {
            this._data = new Data();
            Initialization();
        }

        private void Initialization()
        {
            this._data.LoadRemember();
            this._data.Load();
            this._data.LoadID();
        }
        /// <summary>
        /// Retourne la bon sauvegarde en fonction de l'utilisateur
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Save SaveFromUser(string username)
        {
            return this._data.Saves.FirstOrDefault(x => x.Users.FirstOrDefault(y => y.Username == username) != null);
        }

        public void Remember(bool isChecked, string username)
        {
            this._data.Remember = isChecked ?  username : string.Empty;
            this._data.WriteRemember();
        }
        public bool IsCorrectID(string username, string password)
        {
            bool isCorrect = false;

            if (this._data.Users != null)
            {
                this._user = this._data.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                if (this._user != null)
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }

    }
}
