using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public enum GenderEnum
    {
        [Description("Tout")]
        all,

        [Description("Homme")]
        man,

        [Description("Femme")]
        woman,

        [Description("Autre")]
        other,

        [Description("Enfant")]
        child,
    }
}
