using LeagueSimulator.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class AddTeam: ViewComponent
    {
        public AddTeam()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
      

    }
}
