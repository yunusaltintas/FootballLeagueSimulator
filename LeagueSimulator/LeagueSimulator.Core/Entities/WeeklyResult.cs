using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeagueSimulator.Core.Entities
{
    public class WeeklyResult : BaseEntity
    {
        public int Week { get; set; }   
        public int HomeTeamId { get; set; }      
        public int AwayTeamId { get; set; }
        public int HomeTeamGoal { get; set; }
        public int AwayTeamGoal { get; set; }
        public virtual Team Team { get; set; }
    }
}
