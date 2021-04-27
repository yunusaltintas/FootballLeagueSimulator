using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class TeamBuilder : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.HasMany(i => i.WeeklyResults).WithOne(i => i.Team).HasForeignKey(i => i.HomeTeamId);
            builder.HasMany(i => i.WeeklyResults).WithOne(i => i.Team).HasForeignKey(i => i.AwayTeamId);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Attack).HasDefaultValue(0);
            builder.Property(x => x.Defense).HasDefaultValue(0);
            builder.Property(x => x.Chance).HasDefaultValue(0);
        }
    }
}
