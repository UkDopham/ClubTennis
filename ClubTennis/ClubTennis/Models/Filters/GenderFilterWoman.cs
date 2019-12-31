using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models.Filters
{
    public class GenderFilterWoman : Filter
    {
        public override List<People> Order(List<People> peoples)
        {
            return peoples.Where(x => x.Gender == GenderEnum.woman).ToList();
        }
    }
}
