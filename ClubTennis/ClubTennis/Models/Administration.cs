using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Administration : People , IEmployee
    {
        private DateTime _entryDate;
        private int _salary;
        private BankDetails _bankDetails;

    public BankDetails BankDetails
        {
            get
            {
                return this._bankDetails;
            }
            set
            {
                this._bankDetails = value;
            }
        }
        public int Salary 
        {
            get
            {
                return this._salary;
            }
            set
            {
                this._salary = value;
            }
        }
        public DateTime EntryDate 
        {
            get
            {
                return this._entryDate;
            }
            set
            {
                this._entryDate = value;
            }
        }

        public Administration(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            DateTime birthdate,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate)
        {
            this._entryDate = entryDate;
            this._bankDetails = bankDetails;
            this._salary = salary;
        }

        public Administration(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            DateTime birthdate,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            Guid guid)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate)
        {
            this._entryDate = entryDate;
            this._bankDetails = bankDetails;
            this._salary = salary;
        }
        public override PostEnum GetType()
        {
            return PostEnum.Administration;
        }
    }
}
