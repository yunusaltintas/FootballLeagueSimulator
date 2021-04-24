using LeagueSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.EntityTypeBuilder
{
    public class PuanTableTypeBuilder : IEntityTypeConfiguration<PuanTable>
    {
        public void Configure(EntityTypeBuilder<PuanTable> builder)
        {
            builder.HasOne(i => i.Teams).WithOne(i => i.PuanTable).HasForeignKey<PuanTable>(i => i.TeamId);
            builder.Property(p => p.Id).IsRequired().UseIdentityColumn(1, 1);
          
           
        }
    }
}
