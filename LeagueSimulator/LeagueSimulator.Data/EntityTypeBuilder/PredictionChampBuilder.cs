using LeagueSimulator.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class PredictionChampBuilder : IEntityTypeConfiguration<PredictionChamp>
    {
        public void Configure(EntityTypeBuilder<PredictionChamp> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Team).WithOne(x => x.PredictionChamp).HasForeignKey<PredictionChamp>(x => x.TeamId);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.Prediction).HasDefaultValue(0).HasColumnType("decimal(18,2)");


        }
        
    }
}
