using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models.Filters
{
    public class CompetitionFilter : Filter
    {
        public override List<People> Order(List<People> peoples)
        {
            List<People> tmp = new List<People>();
            peoples.ForEach(x => tmp.Add(x));
            tmp.Sort((x, y) => ((Member)x).ClassementValue().CompareTo(((Member)y).ClassementValue()));

            return tmp;
        }
    }
}
