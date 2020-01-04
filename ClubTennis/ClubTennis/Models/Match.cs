using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Match
    {
        private List<Participant> _teamA;
        private List<Participant> _teamB;

        public Match(List<Participant> teamA, List<Participant> teamB)
        {
            this._teamA = teamA;
            this._teamB = teamB;
        }
    }
}
