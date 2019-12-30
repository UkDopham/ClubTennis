using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models.Filters
{
    public class SearchFilter : Filter
    {
        private string _searchString;

        public SearchFilter(string searchString)
        {
            this._searchString = searchString.ToUpper();
        }
        public override List<People> Order(List<People> peoples)
        {
            return peoples.Where(x => x.LastName.ToUpper().Contains(this._searchString)).ToList();
        }
    }
}
