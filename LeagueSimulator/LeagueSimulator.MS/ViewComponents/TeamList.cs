using LeagueSimulator.Data.Entities;
using LeagueSimulator.Repository;
using LeagueSimulator.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class TeamList:ViewComponent
    {
        private readonly INextWeekService _nextWeekService;

        public TeamList(INextWeekService nextWeekService)
        {
            _nextWeekService = nextWeekService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var result= await _nextWeekService.GetTeamList();
            return View(result);
        }
    }
}
