using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public enum PaymentEnum
    {
        [Description("Tout")]
        all,

        [Description("Payé")]
        paid,

        [Description("En retard")]
        late,
    }
}
