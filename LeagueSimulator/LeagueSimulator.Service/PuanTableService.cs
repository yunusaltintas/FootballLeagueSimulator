using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.ResponseModel;
using LeagueSimulator.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Service
{
    public class PuanTableService : IPuanTableServive
    {
        private readonly IBaseRepository<PuanTable> _puanTableRepository;
        private readonly IBaseRepository<WeeklyResult> _weeklyResultRepository;

        public PuanTableService(
            IBaseRepository<PuanTable> puanTableRepository,
            IBaseRepository<WeeklyResult> weeklyResultRepository)
        {
            _puanTableRepository = puanTableRepository;
            _weeklyResultRepository = weeklyResultRepository;
        }
        public async Task<ReturnParameterModel<List<PuanTable>>> GetPuanTable()
        {
            var result = await _puanTableRepository.TQuery().OrderByDescending(i=>i.Point).Include("Teams").ToListAsync();
            if (result == null)
            {
                return new ReturnParameterModel<List<PuanTable>>("Hata oluştu.");
            }
            return new ReturnParameterModel<List<PuanTable>>(result);
        }
        public async Task<ReturnParameterModel<List<PuanTable>>> AddResultsToTable(int week)
        {
            var result = _weeklyResultRepository.TFindAsync(x => x.Week == week);

            foreach (var item in result)
            {
                var hometeam = await _puanTableRepository.TFetchSingleAsync(x => x.TeamId==item.HomeTeamId);
                var awayteam = await _puanTableRepository.TFetchSingleAsync(x => x.TeamId == item.AwayTeamId);

                //puan galibiyet beraberlik malübiyet
                if (item.AwayTeamGoal ==item.HomeTeamGoal)
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
                hometeam.Averaj += hometeam.GoalsScored - hometeam.GoalsConceded;
                awayteam.Averaj += awayteam.GoalsScored - awayteam.GoalsConceded;

                await _puanTableRepository.TUpdateAsync(hometeam);
                await _puanTableRepository.TUpdateAsync(awayteam);


            }

            return null;
        }
    }
}
