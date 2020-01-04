using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Internship : Event
    {
        private int _price;
        private List<Member> _participants;
        private Trainer _trainer;
        public Internship(string name, 
            int price,
            List<Member> participants,
            Trainer trainer):base(name)
        {
            this._participants = participants;
            this._trainer = trainer;
            this._price = price;
        }
    }
}
