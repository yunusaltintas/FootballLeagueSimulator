using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
    public class WeeklyResultWithTeamDTO:WeeklyResultDTO
    {
        public TeamDTO Team { get; set; }
    }
}
