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
    public class PuanTable:ViewComponent
    {
        private readonly IPuanTableService _puanTableService;
        private readonly IMapper _mapper;

        public PuanTable(IPuanTableService puanTableService,IMapper mapper)
        {
            _puanTableService = puanTableService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var PuanTable=await _puanTableService.GetPuanTableWithTeamNameAsync();
            var result = _mapper.Map<List<PuanTableWithTeamDTO>>(PuanTable);


            return View(result);
        }
    }
}
