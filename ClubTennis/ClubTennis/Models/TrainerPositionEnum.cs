using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public enum TrainerPositionEnum
    {
        [Description("Indépendant")]
        independent,

        [Description("Salarié")]
        employee,
    }
}
