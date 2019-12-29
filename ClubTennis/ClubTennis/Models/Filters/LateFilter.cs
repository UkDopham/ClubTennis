using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models.Filters
{
    public class LateFilter : Filter
    {
        public override List<People> Order(List<People> peoples)
        {
            return peoples.Where(x => !((Member)x).HasPaid).ToList();
        }
    }
}
