using LeagueSimulator.Core.IRepositories;
using LeagueSimulator.Core.IUnitOfWorks;
using LeagueSimulator.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Data.UnitOfWorksBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeagueDbContext _context;
        private  PuanTableRepository _puanTableRepository;
        private  WeeklyResultRepository _weeklyResultRepository;
        public IPuanTableRepository PuanTableRepositories => _puanTableRepository = _puanTableRepository ?? new PuanTableRepository(_context);

        public IWeeklyResultRepository WeeklyResultRepositories => _weeklyResultRepository = _weeklyResultRepository ?? new WeeklyResultRepository(_context);

        public UnitOfWork(LeagueDbContext leagueDbContext)
        {
            _context = leagueDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
