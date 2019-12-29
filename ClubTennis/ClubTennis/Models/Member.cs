using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Member : People
    {
        private bool _hasPaid;
        private string _classement;

        public string Classement
        {
            get
            {
                return this._classement;
            }
            set
            {
                this._classement = value;
            }
        }
        public bool HasPaid
        {
            get
            {
                return this._hasPaid;
            }
            set
            {
                this._hasPaid = value;
            }
        }
        public Member(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            bool hasPaid) 
            : base (firstName, lastName, phoneNumber, gender, adress)
        {
            this._hasPaid = hasPaid;
            this._classement = string.Empty;
        }

        public Member(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            bool hasPaid,
            string classement)
            : base(firstName, lastName, phoneNumber, gender, adress)
        {
            this._hasPaid = hasPaid;
            this._classement = classement;
        }

        public override string ToString()
        {
            return $"{PeopleEnum.Member};{base.ToString()};{this._hasPaid}";
        }

        public override string GetType()
        {
            return "Membre";
        }

        /// <summary>
        /// Retourne une valeur en fonction du classement pour simplifier le tri
        /// </summary>
        /// <returns></returns>
        public int ClassementValue()
        {
            int value = -1;

            switch(this._classement)
            {
                case "40":
                    value = 0;
                    break;

                case "30/5":
                    value = 1;
                    break;

                case "30/4":
                    value = 2;
                    break;

                case "30/3":
                    value = 3;
                    break;

                case "30/2":
                    value = 4;
                    break;

                case "30/1":
                    value = 5;
                    break;

                case "30":
                    value = 6;
                    break;

                case "15/5":
                    value = 7;
                    break;

                case "15/4":
                    value = 8;
                    break;

                case "15/3":
                    value = 9;
                    break;

                case "15/2":
                    value = 10;
                    break;

                case "15/1":
                    value = 11;
                    break;

                case "15":
                    value = 12;
                    break;

                case "5/6":
                    value = 13;
                    break;

                case "4/6":
                    value = 14;
                    break;

                case "3/6":
                    value = 15;
                    break;

                case "2/6":
                    value = 16;
                    break;

                case "1/6":
                    value = 17;
                    break;

                case "0":
                    value = 18;
                    break;

                case "-2/6":
                    value = 19;
                    break;

                case "-4/6":
                    value = 20;
                    break;

                case "-15":
                    value = 21;
                    break;

                case "-30":
                    value = 22;
                    break;

                case "promotion":
                    value = 23;
                    break;

            }

            return value;
        }
    }
}
