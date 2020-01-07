using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public enum PostEnum
    {
        [Description("Personne")]
        People,

        [Description("Membre")]
        Member,

        [Description("Entraineur")]
        Trainer,

        [Description("Administration")]
        Administration,
    }
}
