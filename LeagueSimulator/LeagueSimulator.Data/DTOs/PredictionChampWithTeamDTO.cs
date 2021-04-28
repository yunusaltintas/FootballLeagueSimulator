using LeagueSimulator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
    public class PredictionChampWithTeamDTO
    {
        public int Prediction { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
