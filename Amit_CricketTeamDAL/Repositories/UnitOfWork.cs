using Amit_CricketTeamDAL.DBContextF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amit_CricketTeamDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContextFiledb _dbContext;
        public UnitOfWork(DBContextFiledb dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dbContext.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
