using AutoMapper;
using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class WeeklyResult : ViewComponent
    {
        private readonly IWeeklyResultService _weeklyResultService;
        private readonly IMapper _mapper;
        private readonly IBaseService<Team> _baseService;

        public WeeklyResult(IWeeklyResultService weeklyResultService, IMapper mapper, IBaseService<Team> baseService)
        {
            _weeklyResultService = weeklyResultService;
            _mapper = mapper;
            _baseService = baseService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int week)
        {
            int k = 0;
            ViewBag.wweek = week;
            var weeklyResults = await _weeklyResultService.GetWeeklyResultWithTeamNameAsync(week);

            foreach (var item in weeklyResults)
            {
                
                if (k == 0)
                {
                    var FirstHomeTeam = await _baseService.SingleOrDefaultAsync(x => x.Id == item.HomeTeamId);
                    ViewBag.FirstHomeTeam = FirstHomeTeam.Name;
                    var FirstAwayTeam = await _baseService.SingleOrDefaultAsync(x => x.Id == item.AwayTeamId);
                    ViewBag.FirstAwayTeam = FirstAwayTeam.Name;
                    k++;
                }

                else
                {
                    var SecondHomeTeam = await _baseService.SingleOrDefaultAsync(x => x.Id == item.HomeTeamId);
                    ViewBag.SecondHomeTeam = SecondHomeTeam.Name;
                    var SecondAwayTeam = await _baseService.SingleOrDefaultAsync(x => x.Id == item.AwayTeamId);
                    ViewBag.SecondAwayTeam = SecondAwayTeam.Name;
                }


            }

            return View(_mapper.Map<List<WeeklyResultWithTeamDTO>>(weeklyResults));
        }
    }
}
