using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public enum ClassementEnum
    {
        [Description("Non classé")]
        NC,

        [Description("30/5")]
        trentecinq,

        [Description("30/4")]
        trentequarte,

        [Description("30/3")]
        trentetrois,

        [Description("30/2")]
        trentedeux,

        [Description("30/1")]
        trenteun,

        [Description("30")]
        trente,

        [Description("15/5")]
        quinzecinq,

        [Description("15/4")]
        quinzequatre,

        [Description("15/3")]
        quinzetrois,

        [Description("15/2")]
        quinzedeux,

        [Description("15/1")]
        quinzeun,

        [Description("15")]
        quinze,

        [Description("5/6")]
        cinqsix,

        [Description("4/6")]
        quatresix,

        [Description("3/6")]
        troissix,

        [Description("1/6")]
        unsix,

        [Description("0")]
        zero,

        [Description("-2/6")]
        moinsdeuxsix,

        [Description("-4/6")]
        moinsquatresix,

        [Description("-15")]
        moinsquinze,

        [Description("-30")]
        moinstrente,

        [Description("Promotion")]
        promotion,
    }
}
