using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Seeds
{
    public class WeeklyResultSeed : IEntityTypeConfiguration<WeeklyResult>
    {
        public void Configure(EntityTypeBuilder<WeeklyResult> builder)
        {
            //builder.HasData(
            //    new WeeklyResult { Id = 1, Week = 1, HomeTeamName = "Kocaelispor", AwayTeamName = "Real Madrid" },
            //    new WeeklyResult { Id = 2, Week = 1, HomeTeamName = "Barcalona", AwayTeamName = "Bayern Münih" },
            //    new WeeklyResult { Id = 3, Week = 2, HomeTeamName = "Real Madrid", AwayTeamName = "Barcalona" },
            //    new WeeklyResult { Id = 4, Week = 2, HomeTeamName = "Bayern Münih", AwayTeamName = "Kocaelispor" },
            //    new WeeklyResult { Id = 5, Week = 3, HomeTeamName = "Barcalona", AwayTeamName = "Kocaelispor" },
            //    new WeeklyResult { Id = 6, Week = 3, HomeTeamName = "Real Madrid", AwayTeamName = "Bayern Münih" },
            //    new WeeklyResult { Id = 7, Week = 4, HomeTeamName = "Bayern Münih", AwayTeamName = "Barcalona" },
            //    new WeeklyResult { Id = 8, Week = 4, HomeTeamName = "Real Madrid", AwayTeamName = "Kocaelispor" },
            //    new WeeklyResult { Id = 9, Week = 5, HomeTeamName = "Kocaelispor", AwayTeamName = "Barcalona" },
            //    new WeeklyResult { Id = 10, Week = 5, HomeTeamName = "Bayern Münih", AwayTeamName = "Real Madrid" },
            //    new WeeklyResult { Id = 11, Week = 6, HomeTeamName = "Kocaelispor", AwayTeamName = "Bayern Münih" },
            //    new WeeklyResult { Id = 12, Week = 6, HomeTeamName = "Barcalona", AwayTeamName = "Real Madrid" }
            //    );

            builder.HasData(
                new WeeklyResult { Id = 1, Week = 1, HomeTeamId = 1, AwayTeamId = 2 },
                new WeeklyResult { Id = 2, Week = 1, HomeTeamId = 3, AwayTeamId = 4 },
                new WeeklyResult { Id = 3, Week = 2, HomeTeamId = 2, AwayTeamId = 3 },
                new WeeklyResult { Id = 4, Week = 2, HomeTeamId = 4, AwayTeamId = 1 },
                new WeeklyResult { Id = 5, Week = 3, HomeTeamId = 3, AwayTeamId = 1 },
                new WeeklyResult { Id = 6, Week = 3, HomeTeamId = 2, AwayTeamId = 4 },
                new WeeklyResult { Id = 7, Week = 4, HomeTeamId = 4, AwayTeamId = 3 },
                new WeeklyResult { Id = 8, Week = 4, HomeTeamId = 2, AwayTeamId = 1 },
                new WeeklyResult { Id = 9, Week = 5, HomeTeamId = 1, AwayTeamId = 3 },
                new WeeklyResult { Id = 10, Week = 5, HomeTeamId = 4, AwayTeamId = 2 },
                new WeeklyResult { Id = 11, Week = 6, HomeTeamId = 1, AwayTeamId = 4 },
                new WeeklyResult { Id = 12, Week = 6, HomeTeamId = 3, AwayTeamId = 2 }
                );
        }
    }
}
