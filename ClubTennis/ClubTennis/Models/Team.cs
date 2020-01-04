using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Team
    {
        private List<Participant> _players;
        private Participant _captain;

        public Team(List<Participant> players, Participant captain)
        {
            this._players = players;
            this._captain = captain;
        }

    }
}
