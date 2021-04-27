using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
    public class PuanTableDTO
    {
        public int Point { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Averaj { get; set; }
    }
}
