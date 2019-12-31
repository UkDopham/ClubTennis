using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Trainer : Employee
    {
        private TrainerPositionEnum _position; //TODO ASK FOR INFORMATION

        public TrainerPositionEnum Position
        {
            get
            {
                return this._position;
            }
        }
        public Trainer(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            TrainerPositionEnum position)
            : base(firstName, lastName, phoneNumber, gender, adress, bankDetails, salary, entryDate)
        {
            this._position = position;
        }

        public Trainer(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate,
            TrainerPositionEnum position,
            Guid guid)
            : base(firstName, lastName, phoneNumber, gender, adress, bankDetails, salary, entryDate, guid)
        {
            this._position = position;
        }
        public override PostEnum GetType()
        {
            return PostEnum.Trainer;
        }
    }
}
