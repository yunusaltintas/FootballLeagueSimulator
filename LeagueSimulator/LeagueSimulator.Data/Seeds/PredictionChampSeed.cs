using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Seeds
{
    public class PredictionChampSeed : IEntityTypeConfiguration<PredictionChamp>
    {
        public void Configure(EntityTypeBuilder<PredictionChamp> builder)
        {
            builder.HasData(
                new PredictionChamp { Id = 1, TeamId = 1 },
                new PredictionChamp { Id = 2, TeamId = 2 },
                new PredictionChamp { Id = 3, TeamId = 3 },
                new PredictionChamp { Id = 4, TeamId = 4 });
        }
    }
}
