using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public abstract class Filter
    {
        public virtual List<People> Order(List<People> peoples)
        {
            return new List<People>();
        }
    }
}
