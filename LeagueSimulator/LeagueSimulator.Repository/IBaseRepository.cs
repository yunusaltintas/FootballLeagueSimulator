using LeagueSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Repository
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T> TAddAsync(T Entity);
        Task<bool> TRemoveAsync(int id);
        Task<T> TUpdateAsync(T Entity);
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
        IQueryable<T> TQuery();
        Task<T> TFetchSingleAsync(Expression<Func<T, bool>> predicate);
        List<T> TFindAsync(Expression<Func<T, bool>> predicate);
    }
}
