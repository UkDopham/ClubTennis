using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Member : People, IComparable<Member>
    {
        private bool _hasPaid;

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
        }

        public override string ToString()
        {
            return $"{PeopleEnum.Member};{base.ToString()};{this._hasPaid}";
        }

        public override string GetType()
        {
            return "Membre";
        }

        public int CompareTo(Member other)
        {
            return string.Compare(this.LastName, other.LastName);
        }
    }
}
