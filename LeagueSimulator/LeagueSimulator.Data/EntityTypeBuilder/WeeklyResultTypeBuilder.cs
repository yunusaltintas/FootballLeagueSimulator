using LeagueSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class WeeklyResultTypeBuilder : IEntityTypeConfiguration<WeeklyResult>
    {
        public void Configure(EntityTypeBuilder<WeeklyResult> builder)
        {
            builder.HasOne(i => i.Teams).WithOne(i => i.WeeklyResults).HasForeignKey<WeeklyResult>(i => i.HomeTeamId);
            builder.HasOne(i => i.Teams).WithOne(i => i.WeeklyResults).HasForeignKey<WeeklyResult>(i => i.AwayTeamId);

            builder.Property(p => p.Id).IsRequired().UseIdentityColumn(1, 1);
        }
    }
}
