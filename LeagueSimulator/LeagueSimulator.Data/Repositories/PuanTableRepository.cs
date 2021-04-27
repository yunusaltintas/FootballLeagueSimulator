using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IRepositories;
using LeagueSimulator.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Data.Repositories
{
    public class PuanTableRepository : Repository<PuanTable>, IPuanTableRepository
    {
        private readonly LeagueDbContext context;
        private readonly DbSet<PuanTable> _dbPuanTable;

        public PuanTableRepository(LeagueDbContext Context) : base(Context)
        {
            this.context = Context;
            _dbPuanTable = context.Set<PuanTable>();

        }
        public async Task<List<PuanTable>> GetPuanTableWithTeamNameAsync()
        {
            return await _dbPuanTable.Include(x=>x.Team).OrderByDescending(x=>x.Point).ToListAsync(); 
        }
    }
}
