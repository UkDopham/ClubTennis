using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public abstract class Employee : People
    {
        private BankDetails _bankDetails;
        private int _salary;
        private DateTime _entryDate;

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
        public Employee(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            Guid guid) 
            : base(firstName, lastName, phoneNumber, gender, adress, guid)
        {
            this._bankDetails = bankDetails;
            this._salary = salary;
            this._entryDate = entryDate;
        }

        public Employee(
           string firstName,
           string lastName,
           string phoneNumber,
           GenderEnum gender,
           string adress,
           BankDetails bankDetails,
           int salary,
           DateTime entryDate)
           : base(firstName, lastName, phoneNumber, gender, adress)
        {
            this._bankDetails = bankDetails;
            this._salary = salary;
            this._entryDate = entryDate;
        }

        public override string ToString()
        {
            return $"{PeopleEnum.Employee};{base.ToString()};{this._bankDetails};{this._entryDate}";
        }

    }
}
