using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.ResponseModel;
using LeagueSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Service
{
    public interface INextWeekService
    {
        ReturnParameterModel<List<WeeklyResult>> GetWeeklyResult(int week);
        ReturnModel DrawLots();
        Task<ReturnParameterModel<Team>> AddTeamAsync(AddTeamViewModel addTeamViewModel);
        Task<ReturnParameterModel<List<Team>>> GetTeamList();
    }
}
