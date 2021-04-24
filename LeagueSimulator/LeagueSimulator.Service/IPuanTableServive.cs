using LeagueSimulator.Data.Entities;
using LeagueSimulator.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Service
{
    public interface IPuanTableServive
    {
        Task<ReturnParameterModel<List<PuanTable>>> GetPuanTable();
        Task<ReturnParameterModel<List<PuanTable>>> AddResultsToTable(int week);
    }
}
