using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.EntityTypeBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data
{
    public class LeagueSimulatorDbContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }
        public DbSet<PuanTable> PuanTables { get; set; }
        public DbSet<WeeklyResult> WeeklyResults { get; set; }

        public LeagueSimulatorDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PuanTableTypeBuilder())
                        .ApplyConfiguration(new TeamTypeBuilder())
                        .ApplyConfiguration(new WeeklyResultTypeBuilder());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
