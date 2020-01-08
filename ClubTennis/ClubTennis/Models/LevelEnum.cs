using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public enum LevelEnum
    {
        [Description("Départemental")]
        departemental,

        [Description("Regional")]
        regional,

        [Description("National")]
        national,

        [Description("International")]
        international,

    }
}
