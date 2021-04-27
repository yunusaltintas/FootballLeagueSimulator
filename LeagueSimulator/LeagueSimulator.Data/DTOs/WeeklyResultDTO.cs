using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
   public class WeeklyResultDTO
    {
        public int Week { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoal { get; set; }
        public int AwayTeamGoal { get; set; }
    }
}
