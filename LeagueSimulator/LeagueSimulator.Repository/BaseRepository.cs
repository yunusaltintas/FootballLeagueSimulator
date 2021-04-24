﻿using LeagueSimulator.Data;
using LeagueSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSimulator.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:BaseEntity
    {
        private readonly LeagueSimulatorDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(LeagueSimulatorDbContext ticaretDbContext)
        {
            _context = ticaretDbContext;
            _db = _context.Set<T>();
        }
        public async Task<T> TAddAsync(T Entity)
        {
            await _db.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> TFetchSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _db.Where(predicate).FirstOrDefaultAsync();
            return result;
        }

        public List<T> TFindAsync(Expression<Func<T, bool>> predicate)
        {
            var result=_db.Where(predicate).ToList();
            return result;
        }

        public async Task<List<T>> TGetAllAsync()
        {
            return await _db.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _db.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<T> TQuery()
        {
            return _db.AsQueryable();
        }

        public async Task<bool> TRemoveAsync(int id)
        {
            var result = await _db.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _db.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<T> TUpdateAsync(T Entity)
        {
            _db.Update(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
