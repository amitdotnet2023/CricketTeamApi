using Amit_CricketTeamDAL.DBContextF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamDAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContextFiledb _dbContext;

        public Repository(DBContextFiledb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await GetByIdAsync(Id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
