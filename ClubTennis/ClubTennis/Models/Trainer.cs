using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Trainer : Member , IEmployee
    {
        private BankDetails _bankDetails;
        private int _salary;
        private DateTime _entryDate;
        private TrainerPositionEnum _position; //TODO ASK FOR INFORMATION

        public TrainerPositionEnum Position
        {
            get
            {
                return this._position;
            }
        }

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

        public Trainer(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            DateTime birthdate,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            TrainerPositionEnum position)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate, true)
        {
            this._bankDetails = bankDetails;
            this._salary = salary;
            this._entryDate = entryDate;
            this._position = position;
        }

        public Trainer(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            DateTime birthdate,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            TrainerPositionEnum position,
            Guid guid)
            : base(firstName, lastName, phoneNumber, gender, adress, birthdate, true, guid)
        {
            this._position = position;
        }
        public override PostEnum GetType()
        {
            return PostEnum.Trainer;
        }
    }
}
