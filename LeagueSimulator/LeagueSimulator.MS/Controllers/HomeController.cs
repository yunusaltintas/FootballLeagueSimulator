using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.ViewModels;
using LeagueSimulator.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.Controllers
{
    public class HomeController : Controller
    {
        private readonly INextWeekService _nextWeekService;
        private readonly IPuanTableServive _puanTableServive;
        static int week;
        public HomeController(INextWeekService nextWeekService, IPuanTableServive puanTableServive)
        {
            _nextWeekService = nextWeekService;
            _puanTableServive = puanTableServive;
        }
        static HomeController()
        {
            week = 0;
        }

        public IActionResult Index()
        {
            ViewBag.week = week;
            if (week == 0)
            {
                //_nextWeekService.DrawLots();
            }
            //_puanTableServive.AddResultsToTable(week);
            return View();
        }
        [HttpGet]
        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
        [Route("/Error")]
        [HttpGet]
        public IActionResult Error()
        {
            var ErrorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(NLog.LogLevel.Error, $"\nHatanın Gerçekleştiği yer:{ErrorInfo.Path}\nHata Mesajı: {ErrorInfo.Error.Message}\nStack Trace:{ErrorInfo.Error.StackTrace}");
            return View();
        }
        [HttpGet]
        public IActionResult NextWeek()
        {
            if (week<6)
            {
                week++;
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(AddTeamViewModel addTeamViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addTeamViewModel);
            }
           
            var result = _nextWeekService.AddTeamAsync(addTeamViewModel);
            return RedirectToAction("AddTeam");
        }




    }
}
