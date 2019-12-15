using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class BankDetails
    {
        private string _rib;
        private string _iban;

        public BankDetails(string rib, string iban)
        {
            this._rib = rib;
            this._iban = iban;
        }

        public override string ToString()
        {
            return $"{this._rib};{this._iban}";
        }
    }
}
