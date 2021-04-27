using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class PuanTableBuilder : IEntityTypeConfiguration<PuanTable>
    {
        public void Configure(EntityTypeBuilder<PuanTable> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.Team).WithOne(i => i.PuanTable).HasForeignKey<PuanTable>(i => i.TeamId);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Point).HasDefaultValue(0);
            builder.Property(x => x.Win).HasDefaultValue(0);
            builder.Property(x => x.Lose).HasDefaultValue(0);
            builder.Property(x => x.Draw).HasDefaultValue(0);
            builder.Property(x => x.GoalsScored).HasDefaultValue(0);
            builder.Property(x => x.GoalsConceded).HasDefaultValue(0);
            builder.Property(x => x.Averaj).HasDefaultValue(0);



        }
    }
}
