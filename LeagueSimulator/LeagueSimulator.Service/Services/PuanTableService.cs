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
    public class PuanTableService : BaseService<PuanTable>, IPuanTableService
    {
        public PuanTableService(IUnitOfWork unitOfWork, IRepository<PuanTable> repository) : base(unitOfWork, repository)
        {
        }
        
        public async Task<List<PuanTable>> GetPuanTableWithTeamNameAsync()
        {
            return await _unitOfWork.PuanTableRepositories.GetPuanTableWithTeamNameAsync();
            
        }

        public async Task AddResultsToTableAsync(int week)
        {
            var result = await _unitOfWork.WeeklyResultRepositories.Where(x => x.Week == week);
            foreach (var item in result)
            {
                var hometeam = await _unitOfWork.PuanTableRepositories.SingleOrDefaultAsync(x => x.TeamId == item.HomeTeamId);
                var awayteam = await _unitOfWork.PuanTableRepositories.SingleOrDefaultAsync(x => x.TeamId == item.AwayTeamId);

                //puan galibiyet beraberlik malübiyet
                if (item.AwayTeamGoal == item.HomeTeamGoal)
                {
                    hometeam.Point += 1;
                    awayteam.Point += 1;
                    hometeam.Draw += 1;
                    awayteam.Draw += 1;
                }
                else if (item.AwayTeamGoal > item.HomeTeamGoal)
                {
                    awayteam.Point += 3;
                    awayteam.Win += 1;
                    hometeam.Lose += 1;

                }
                else if (item.AwayTeamGoal < item.HomeTeamGoal)
                {
                    hometeam.Point += 3;
                    hometeam.Win += 1;
                    awayteam.Lose += 1;
                }

                //ev sahini gol sayıssı
                hometeam.GoalsScored += item.HomeTeamGoal;
                hometeam.GoalsConceded += item.AwayTeamGoal;
                //deplasman gol sayılaro
                awayteam.GoalsScored += item.AwayTeamGoal;
                awayteam.GoalsConceded += item.HomeTeamGoal;
                //averaj
                hometeam.Averaj += (item.HomeTeamGoal - item.AwayTeamGoal);
                awayteam.Averaj += (item.AwayTeamGoal - item.HomeTeamGoal);

                _unitOfWork.PuanTableRepositories.Update(hometeam);
                _unitOfWork.PuanTableRepositories.Update(awayteam);

               await _unitOfWork.CommitAsync();

            }
        }
        public async Task Reset()
        {

            var puanTable = await _unitOfWork.PuanTableRepositories.GetAllAsync();
            foreach (var item in puanTable)
            {
                item.Point = 0; item.Win = 0; item.Draw = 0; item.Lose = 0; item.GoalsConceded = 0; item.GoalsScored = 0; item.Averaj = 0;

                _unitOfWork.PuanTableRepositories.Update(item);
                _unitOfWork.Commit();
                    
            }
        }

    }
}
