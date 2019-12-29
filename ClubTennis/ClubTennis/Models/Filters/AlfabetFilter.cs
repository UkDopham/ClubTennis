using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class AlfabetFilter : Filter
    {
        public override List<People> Order(List<People> peoples)
        {
            List<People> tmp = new List<People>();
            peoples.ForEach(x => tmp.Add(x));
            tmp.Sort();

            return tmp;
        }
    }
}
