﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeagueSimulator.Core.Entities
{
    public class PuanTable:BaseEntity
    {
        public int Point { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Averaj { get; set; }       
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

    }
}
