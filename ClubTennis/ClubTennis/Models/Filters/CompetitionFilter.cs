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
            List<People> tmp = peoples.Where(x => x.GetType() == PostEnum.Member).ToList();
            tmp.Sort((x, y) => ((Member)x).Classement.CompareTo(((Member)y).Classement));

            return tmp;
        }
    }
}
