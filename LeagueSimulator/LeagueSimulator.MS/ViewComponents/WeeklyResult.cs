using LeagueSimulator.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class WeeklyResult : ViewComponent
    {
       
        private readonly INextWeekService _nextWeekService;

        
        public WeeklyResult(INextWeekService nextWeekService)
        {
            _nextWeekService = nextWeekService;
        }
        
        public IViewComponentResult Invoke(int week)
        {
           
            ViewBag.wweek = week;
           
            var result=_nextWeekService.GetWeeklyResult(week);
            return View(result);
        }

    }
}
