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
        private ClassementEnum _classement;
        public ClassementEnum Classement
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
            DateTime birthdate,
            bool hasPaid,
            ClassementEnum classement)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate)
        {
            this._hasPaid = hasPaid;
            this._classement = classement;
        }

        public Member(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            DateTime birthdate,
            bool hasPaid,
            ClassementEnum classement, 
            Guid guid)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate, guid)
        {
            this._hasPaid = hasPaid;
            this._classement = classement;
        }

        public override string ToString()
        {
            return $"{PeopleEnum.Member};{base.ToString()};{this._hasPaid}";
        }

        public override PostEnum GetType()
        {
            return PostEnum.Member;
        }
               
    }
}
