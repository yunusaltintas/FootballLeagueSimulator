using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Core.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Chance { get; set; }
        public virtual PuanTable PuanTable { get; set; }
        public virtual ICollection<WeeklyResult> WeeklyResults { get; set; }

    }
}
