﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Member : People
    {
        private bool _hasPaid;

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
        }

        public override string ToString()
        {
            return $"{typeof(Member).Name};{base.ToString()};{this._hasPaid}";
        }
    }
}
