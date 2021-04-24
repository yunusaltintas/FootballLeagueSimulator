using LeagueSimulator.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class PuanTable : ViewComponent
    {
        private readonly IPuanTableServive _puanTableServive;

        public PuanTable(IPuanTableServive puanTableServive)
        {
            _puanTableServive = puanTableServive;
        }

        public async Task<IViewComponentResult> InvokeAsync(int week)
        {
            
            var result =await _puanTableServive.GetPuanTable();
            return View(result);
        }
    }
}
