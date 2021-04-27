﻿using LeagueSimulator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IServices
{
    public interface IPuanTableService:IBaseService<PuanTable>
    {
        Task<List<PuanTable>> GetPuanTableWithTeamNameAsync();
        Task AddResultsToTableAsync(int week);
        Task Reset();
    }
}
