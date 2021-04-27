using AutoMapper;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class WeeklyResult:ViewComponent
    {
        private readonly IWeeklyResultService _weeklyResultService;
        private readonly IMapper _mapper;
      

        public WeeklyResult(IWeeklyResultService weeklyResultService, IMapper mapper)
        {
            _weeklyResultService = weeklyResultService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int week)
        {
            
            ViewBag.wweek = week;
            var weeklyResults=await _weeklyResultService.GetWeeklyResultWithTeamNameAsync(week);
            return View(_mapper.Map<List<WeeklyResultWithTeamDTO>>(weeklyResults));
        }
    }
}
