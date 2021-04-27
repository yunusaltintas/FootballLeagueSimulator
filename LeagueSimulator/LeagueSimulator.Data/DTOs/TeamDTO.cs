using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Chance { get; set; }

    }
}
