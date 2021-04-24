using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.ViewModels
{
   public class AddTeamViewModel
    {
        public string TeamName { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Chance { get; set; }
    }
}
