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
    public class WeeklyResultRepository : Repository<WeeklyResult>, IWeeklyResultRepository
    {
        private readonly LeagueDbContext context;
        private readonly DbSet<WeeklyResult> _dbWeeklyResult;
        public WeeklyResultRepository(LeagueDbContext Context) : base(Context)
        {
            context = Context;
            _dbWeeklyResult = context.Set<WeeklyResult>();
        }

       public async Task<List<WeeklyResult>> GetWeeklyResultWithTeamNameAsync(int week)
        {
            return await _dbWeeklyResult.Include(x => x.Team).Where(x=>x.Week==week).ToListAsync();
        }
    }
}
