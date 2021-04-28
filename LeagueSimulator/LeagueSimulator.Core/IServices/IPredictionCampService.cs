using LeagueSimulator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IServices
{
    public interface IPredictionCampService:IBaseService<PredictionChamp>
    {
        Task<List<PredictionChamp>> GetPredictionTableWithTeamNameAsync();
        Task PredictionChampAsync(int week);
    }
}
