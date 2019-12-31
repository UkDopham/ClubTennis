﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public abstract class People : IComparable<People>
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private GenderEnum _gender;
        private string _adress;
        private Guid _guid;

        public Guid Guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this._phoneNumber;
            }
        }

        public string Adress
        {
            get
            {
                return this._adress;
            }
        }

        public GenderEnum Gender
        {
            get
            {
                return this._gender;
            }
        }
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
            this._guid = Guid.NewGuid();
        }

        public People(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            Guid guid)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._phoneNumber = phoneNumber;
            this._gender = gender;
            this._adress = adress;
            this._guid = guid;
        }


        public override string ToString()
        {
            return $"{this._firstName};{this._lastName};{this._phoneNumber};{this._gender};{this._adress}";
        }

        public virtual PostEnum GetType()
        {
            return PostEnum.People;
        }

        public int CompareTo(People other)
        {
            return string.Compare(this.LastName, other.LastName);
        }
    }
}
