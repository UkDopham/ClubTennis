using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    [Serializable]
    public class Club
    {
        private Administration _administration;
        private List<Trainer> _trainers;

        public Club(Administration administration, List<Trainer> trainers)
        {
            this._administration = administration;
            this._trainers = trainers;
        }
    }
}
