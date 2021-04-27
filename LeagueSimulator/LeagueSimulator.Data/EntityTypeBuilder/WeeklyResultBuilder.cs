using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class WeeklyResultBuilder : IEntityTypeConfiguration<WeeklyResult>
    {
        public void Configure(EntityTypeBuilder<WeeklyResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Team).WithMany(x => x.WeeklyResults).HasForeignKey(x => x.AwayTeamId);
            builder.HasOne(x => x.Team).WithMany(x => x.WeeklyResults).HasForeignKey(x => x.HomeTeamId);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.AwayTeamGoal).HasDefaultValue(0);
            builder.Property(x => x.HomeTeamGoal).HasDefaultValue(0);
        }
    }
}
