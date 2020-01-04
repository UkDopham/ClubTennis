using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTennis.Models
{
    public class Competition : Event
    {
        private ClassementEnum _level;
        private List<People> _participants;
        private int _price;
        private int _duration;
        private DateTime _date;

        private CompetitionTypeEnum _competionTypeEnum;
        private CompetitionAgeTypeEnum _competitionAgeTypeEnum;
        private GenderEnum _genderEnum;
        public Competition(string name, 
            ClassementEnum level, 
            List<People> participants, 
            int price,
            int duration,
            DateTime date,
            CompetitionTypeEnum competitionTypeEnum = CompetitionTypeEnum.solo, 
            CompetitionAgeTypeEnum competitionAgeTypeEnum = CompetitionAgeTypeEnum.all,
            GenderEnum genderEnum = GenderEnum.man) : base (name)
        {
            this._date = date;
            this._duration = duration;
            this._price = price;
            this._genderEnum = genderEnum;
            this._competitionAgeTypeEnum = competitionAgeTypeEnum;
            this._competionTypeEnum = competitionTypeEnum;
            this._level = level;
            this._participants = participants;
        }
    }
}
