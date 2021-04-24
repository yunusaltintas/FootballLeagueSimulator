using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.ResponseModel;
using LeagueSimulator.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeagueSimulator.Data.ViewModels;

namespace LeagueSimulator.Service
{
    public class NextWeekService : INextWeekService
    {
        private readonly IBaseRepository<WeeklyResult> _weekRepository;
        private readonly IBaseRepository<Team> _teamRepository;

        public NextWeekService(IBaseRepository<WeeklyResult> WeekRepository,
            IBaseRepository<Team> teamRepository)
        {
            _weekRepository = WeekRepository;
            _teamRepository = teamRepository;
        }
        public ReturnParameterModel<List<WeeklyResult>> GetWeeklyResult(int week)
        {
         
            var WeekltResultTable =_weekRepository.TFindAsync(x => x.Week == week);
            if (WeekltResultTable == null)
            {
                return new ReturnParameterModel<List<WeeklyResult>>("Beklenmeyen bir durum oluştu.");
            }
            return new ReturnParameterModel<List<WeeklyResult>>(WeekltResultTable);
        }
        public ReturnModel DrawLots()
        {
            List<string> Draw = new List<string>();
            var TeamsIdList = _teamRepository.TQuery().Select(x => x.Id).ToList();
            //int week=0;
            //int home;
            //int away;
            
            
            return null;
        }
        public async Task<ReturnParameterModel<Team>> AddTeamAsync(AddTeamViewModel addTeamViewModel)
        {
            var addTeam = new Team
            {
                TeamName=addTeamViewModel.TeamName,
                Attack= addTeamViewModel.Attack,
                Defense=addTeamViewModel.Defense,
                Chance=addTeamViewModel.Chance
            };
            var result= await _teamRepository.TAddAsync(addTeam);
            if (result.Id==0)
            {
                return new ReturnParameterModel<Team>("hata oluştu.");
            }

            return new ReturnParameterModel<Team>(result); ;
        }

        public async Task<ReturnParameterModel<List<Team>>> GetTeamList()
        {
            var result= await _teamRepository.TGetAllAsync();
            if (result==null)
            {
                return new ReturnParameterModel<List<Team>>("hata oluştu.");
            }

            return new ReturnParameterModel<List<Team>>(result);
        }
    }
}




//var add = new WeeklyResult
//{
//    Week = week,
//    HomeTeamId = home,
//    AwayTeamId = deplasman
//};
//await _baseRepository.TAddAsync(add);
