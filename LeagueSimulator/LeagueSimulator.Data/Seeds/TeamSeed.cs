using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Seeds
{
    public class TeamSeed : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(new Team { Id = 1, Name = "Kocaelispor", Attack = 99, Chance = 99, Defense = 99 },
                new Team { Id = 2, Name = "Read Madrid", Attack = 88, Chance = 85, Defense = 82 },
                new Team { Id = 3, Name = "Barcalona", Attack = 90, Chance = 91, Defense = 80 },
                new Team { Id = 4, Name = "Bayern Münih", Attack = 92, Chance = 88, Defense = 85 }
                );
        }
    }
}
