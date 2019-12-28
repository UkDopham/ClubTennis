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
    }
}
