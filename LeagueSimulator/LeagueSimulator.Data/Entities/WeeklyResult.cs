using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Entities
{
    public class WeeklyResult:BaseEntity
    {
        public int Week { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoal { get; set; }
        public int AwayTeamGoal { get; set; }
        public virtual Team Teams { get; set; }


    }
}
