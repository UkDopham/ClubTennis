using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public abstract class People
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private GenderEnum _gender;
        private string _adress;
        
        public People(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._phoneNumber = phoneNumber;
            this._gender = gender;
            this._adress = adress;
        }

        public override string ToString()
        {
            return $"{this._firstName};{this._lastName};{this._phoneNumber};{this._gender};{this._adress}";
        }
    }
}
