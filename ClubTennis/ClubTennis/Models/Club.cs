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
        private string _name;
        private Administration _administration;
        private List<Trainer> _trainers;

        public string Name
        {
            get
            {
                return this._name;
            }
        }
        public Club(string name, Administration administration, List<Trainer> trainers)
        {
            this._name = name;
            this._administration = administration;
            this._trainers = trainers;
        }
    }
}
