using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IRepositories
{
    public interface IWeeklyResultRepository:IRepository<WeeklyResult>
    {
        Task<List<WeeklyResult>> GetWeeklyResultWithTeamNameAsync(int week);

    }
}
