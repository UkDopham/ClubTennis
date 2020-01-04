using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public interface IEmployee
    {
        BankDetails BankDetails { get; set; }
        int Salary { get; set; }
        DateTime EntryDate { get; set; }
        //string FirstName { get; set; }
        //string LastName { get; set; }
        //DateTime BirthDate { get; set; }
        //string Adress { get; set; }
        //GenderEnum Gender { get; set; }
        //Guid Guid { get; set; }
    }
}
