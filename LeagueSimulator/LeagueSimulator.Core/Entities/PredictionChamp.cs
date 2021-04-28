using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Core.Entities
{
    public class PredictionChamp : BaseEntity
    {
        public decimal Prediction { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
