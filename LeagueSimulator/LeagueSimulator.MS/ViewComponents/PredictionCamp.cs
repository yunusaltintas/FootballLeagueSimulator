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
    public class PredictionCamp : ViewComponent
    {
        private readonly IPredictionCampService _predictionCampService;
        private readonly IMapper _mapper;

        public PredictionCamp(IPredictionCampService predictionCampService, IMapper mapper)
        {
            _predictionCampService = predictionCampService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? week)
        {
            ViewBag.week = week;
            if (4 <= week)
            {
                var predictionCamp = await _predictionCampService.GetPredictionTableWithTeamNameAsync();
                return View(_mapper.Map<List<PredictionChampWithTeamDTO>>(predictionCamp));
            }
            return View();
        }
    }
}
