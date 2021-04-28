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
    public class PredictionCampRepository : Repository<PredictionChamp>, IPredictionCampRepository
    {
        private readonly LeagueDbContext context;
        private readonly DbSet<PredictionChamp> _dbPredictionTable;
        public PredictionCampRepository(LeagueDbContext Context) : base(Context)
        {
            this.context = Context;
            _dbPredictionTable = context.Set<PredictionChamp>();
        }

        public async Task<List<PredictionChamp>> GetPredictionTableWithTeamNameAsync()
        {
            return await _dbPredictionTable.Include(x => x.Team).OrderByDescending(x => x.Prediction).ToListAsync();
            
            
        }

    }
}
