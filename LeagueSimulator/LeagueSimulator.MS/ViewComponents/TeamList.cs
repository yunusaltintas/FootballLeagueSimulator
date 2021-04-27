
using AutoMapper;
using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Data.DTOs;
using LeagueSimulator.Service;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueSimulator.MS.ViewComponents
{
    public class TeamList : ViewComponent
    {
        private readonly IBaseService<Team> _baseService;
        private readonly IMapper _mapper;

        public TeamList(IBaseService<Team> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var TeamList = await _baseService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TeamDTO>>(TeamList);
            return View(result);
        }
    }
}
