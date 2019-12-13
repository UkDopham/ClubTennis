using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Employee : People
    {
        private BankDetails _bankDetails;
        private int _salary;
        private DateTime _entryDate;
        public Employee(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            BankDetails bankDetails,
            int salary,
            DateTime _entryDate) 
            : base(firstName, lastName, phoneNumber, gender, adress)
        {
            this._bankDetails = bankDetails;
            this._salary = salary;
            this._entryDate = _entryDate;
        }

        public override string ToString()
        {
            return $"{typeof(Employee).Name};{base.ToString()};{this._bankDetails};{this._entryDate}";
        }
    }
}
