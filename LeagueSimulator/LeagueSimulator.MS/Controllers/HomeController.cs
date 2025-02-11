﻿
using AutoMapper;
using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Data.DTOs;
using LeagueSimulator.MS.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeeklyResultService _weeklyResultService;
        private readonly IMapper _mapper;
        private readonly IBaseService<Team> _baseService;
        private readonly IPuanTableService _puanTableService;
        private readonly IPredictionCampService _predictionCampService;

        public HomeController(IWeeklyResultService weeklyResultService,IMapper mapper,IBaseService<Team> baseService,IPuanTableService puanTableService, IPredictionCampService predictionCampService )
        {
            _weeklyResultService = weeklyResultService;
            _mapper = mapper;
            _baseService = baseService;
            _puanTableService = puanTableService;
            _predictionCampService = predictionCampService;
        }
        static int staticweek;
        static HomeController()
        {
            staticweek = 0;
        }

        public IActionResult Index()
        {
            ViewBag.week = staticweek;
            return View();
        }
        [HttpGet]
        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
        [HttpGet]
        public IActionResult Error()
        {
            var ErrorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(NLog.LogLevel.Error, $"\nHatanın Gerçekleştiği yer:{ErrorInfo.Path}\nHata Mesajı: {ErrorInfo.Error.Message}\nStack Trace:{ErrorInfo.Error.StackTrace}");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NextWeekAsync()
        {
            if (staticweek >= 0 && staticweek <= 5)
            {
                staticweek++;                
                await  _weeklyResultService.PlayGameAsync(staticweek);
                await _puanTableService.AddResultsToTableAsync(staticweek);
                await _predictionCampService.PredictionChampAsync(staticweek);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PlayAll()
        {
            if (staticweek==6)
            {
                return RedirectToAction("Index");
            }
            for (int week = 0; week <= 6; week++)
            {
                await _weeklyResultService.PlayGameAsync(week);
                await _puanTableService.AddResultsToTableAsync(week);
                staticweek = week;
            } 

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> AddTeamAsync(int? id)
        {
            if (id.HasValue)
            {
                var find = await _baseService.SingleOrDefaultAsync(x => x.Id == id);
                return View(_mapper.Map<TeamDTO>(find));
            }
            return View();
        }

        [ValidationFilter]
        [HttpPost]
        public IActionResult AddTeamAsync(TeamDTO teamDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(teamDTO);
            }
            var team=_mapper.Map<Team>(teamDTO);
            if (team.Id==0)
            {
                return View();

            }
            _baseService.Update(team);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Reset()
        {
            await _puanTableService.Reset();
            staticweek = 0;
            return RedirectToAction("Index");
        }




    }
}
