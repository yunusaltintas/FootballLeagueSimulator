using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Entities
{
    public class Team : BaseEntity
    {
        public string TeamName { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Chance { get; set; }
        public virtual PuanTable PuanTable { get; set; }
        public virtual WeeklyResult WeeklyResults { get; set; }
    }
}
