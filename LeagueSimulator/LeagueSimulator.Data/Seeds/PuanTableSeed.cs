using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.Seeds
{
    public class PuanTableSeed : IEntityTypeConfiguration<PuanTable>
    {
        public void Configure(EntityTypeBuilder<PuanTable> builder)
        {
            builder.HasData(new PuanTable { Id = 1, TeamId = 1 },
                new PuanTable { Id = 2, TeamId = 2 },
                new PuanTable { Id = 3, TeamId = 3 },
                new PuanTable { Id = 4, TeamId = 4 }
                );
        }
    }
}
