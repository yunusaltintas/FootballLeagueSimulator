using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
    public class PuanTableWithTeamDTO:PuanTableDTO
    {
        public TeamDTO Team { get; set; }
    }
}
