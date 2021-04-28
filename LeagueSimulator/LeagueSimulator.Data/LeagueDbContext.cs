using LeagueSimulator.Core.Entities;
using LeagueSimulator.Data.EntityTypeBuilder;
using LeagueSimulator.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data
{
    public class LeagueDbContext:DbContext
    {
        public LeagueDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<PuanTable> PuanTables { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<WeeklyResult> WeeklyResults { get; set; }
        public DbSet<PredictionChamp> PredictionChamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamBuilder())
                .ApplyConfiguration(new WeeklyResultBuilder())
                .ApplyConfiguration(new PuanTableBuilder())
                .ApplyConfiguration(new PredictionChampBuilder());

            modelBuilder.ApplyConfiguration(new TeamSeed())
                .ApplyConfiguration(new PuanTableSeed())
                .ApplyConfiguration(new WeeklyResultSeed())
                .ApplyConfiguration(new PredictionChampSeed());
        }


    }
}
