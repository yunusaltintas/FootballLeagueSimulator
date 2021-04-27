using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IRepository;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Core.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Service.Services
{

    public class WeeklyResultService : BaseService<WeeklyResult>, IWeeklyResultService
    {
        public WeeklyResultService(IUnitOfWork unitOfWork, IRepository<WeeklyResult> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<List<WeeklyResult>> GetWeeklyResultWithTeamNameAsync(int week)
        {
            return await _unitOfWork.WeeklyResultRepositories.GetWeeklyResultWithTeamNameAsync(week);
        }

        public async Task PlayGameAsync(int week)
        {
            var MatchesOfWeek =await _unitOfWork.WeeklyResultRepositories.Where(x => x.Week == week);
            
            foreach (var item in MatchesOfWeek)
            {
                item.HomeTeamGoal = ScoreAsync();
                item.AwayTeamGoal = ScoreAsync();

                _unitOfWork.WeeklyResultRepositories.Update(item);
                
            }
        }
        public int ScoreAsync()
        {
            Random rnd = new Random();
            return rnd.Next(4);

        }



    }
}
