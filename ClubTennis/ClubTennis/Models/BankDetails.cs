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

        public string Rib
        {
            get
            {
                return this._rib;
            }
            set
            {
                this._rib = value;
            }
        }

        public string Iban
        {
            get
            {
                return this._iban;
            }
            set
            {
                this._iban = value;
            }
        }
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
