using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using BigDataETL.Repository.Interfaces;
using BigDataETL.Repository.Domain;

namespace BigDataETL.Repository.Repositories
{
    public abstract class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        #region Backing fields
        private readonly BigDataContext _dbContext;
        #endregion

        #region Constructor
        protected GenericRepository(BigDataContext context)
        {
            _dbContext = context;
        }
        #endregion

        public async Task CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ObservableCollection<E>> GetAllAsync()
        {
            ObservableCollection<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());

            return temp;
        }

        public async Task DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
