using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudySprint.Data.Data;
using StudySprint.Repository.Interfaces;

namespace StudySprint.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly AppDbContext _dbContext;

        public Repository(
            AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(T entity)
        {
            await _dbContext.Set<T>()
                .AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbContext.Set<T>()
                .Remove(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext
                .Set<T>()
                .ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbContext
                .Update(entity);

            await _dbContext
                .SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteById(int id)
        {
            var entity =
                await _dbContext
                .Set<T>()
                .FindAsync(id);

            if (entity == null)
                return false;

            _dbContext
                .Set<T>()
                .Remove(entity);

            await _dbContext
                .SaveChangesAsync();

            return true;
        }
    }
}