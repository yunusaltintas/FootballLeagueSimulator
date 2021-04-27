using LeagueSimulator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IServices
{
    public interface IWeeklyResultService:IBaseService<WeeklyResult>
    {
        Task<List<WeeklyResult>> GetWeeklyResultWithTeamNameAsync(int week);
        Task PlayGameAsync(int week);
    }
}
