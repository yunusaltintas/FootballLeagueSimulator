using LeagueSimulator.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IPuanTableRepository PuanTableRepositories { get; }

        IWeeklyResultRepository WeeklyResultRepositories { get; }

        Task CommitAsync();

        void Commit();
    }
}
