using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Administration : Employee
    {
        public Administration(
            string firstName,
            string lastName,
            string phoneNumber,
            GenderEnum gender,
            string adress,
            BankDetails bankDetails,
            int salary,
            DateTime entryDate)
            : base(firstName, lastName, phoneNumber, gender, adress, bankDetails, salary, entryDate)
        {

        }
    }
}
