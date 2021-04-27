using LeagueSimulator.Core.Entities;
using LeagueSimulator.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IRepositories
{
    public interface IPuanTableRepository : IRepository<PuanTable>
    {
        Task<List<PuanTable>> GetPuanTableWithTeamNameAsync();

    }
}
