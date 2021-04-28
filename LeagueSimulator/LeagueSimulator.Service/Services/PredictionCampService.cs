using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IRepository;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Core.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Service.Services
{
    public class PredictionCampService : BaseService<PredictionChamp>, IPredictionCampService
    {
        public PredictionCampService(IUnitOfWork unitOfWork, IRepository<PredictionChamp> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<List<PredictionChamp>> GetPredictionTableWithTeamNameAsync()
        {
            return await _unitOfWork.PredictionCampRepositories.GetPredictionTableWithTeamNameAsync();
        }
        public async Task PredictionChampAsync(int week)
        {
            
            var PredictionChampsTable = await _unitOfWork.PredictionCampRepositories.GetPredictionTableWithTeamNameAsync();
            var PuanTable = await _unitOfWork.PuanTableRepositories.GetAllAsync();
            
            
            foreach (var predictionChampsTable in PredictionChampsTable)
            {
                decimal totalpoint = 1;
                decimal factor = 0;
                decimal prediction = 0;

                foreach (var team in PuanTable)
                {
                    totalpoint += team.Point;
                    factor = 100 / totalpoint;
                    prediction = factor * predictionChampsTable.Team.PuanTable.Point;

                }

                predictionChampsTable.Prediction = prediction;
                _unitOfWork.PredictionCampRepositories.Update(predictionChampsTable);
                await _unitOfWork.CommitAsync();




            }
        }
    }
}
