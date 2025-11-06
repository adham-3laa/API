using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersintenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersintenceLayer.Repositorys
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _dbContext)
        : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)=>
           await _dbContext.Set<TEntity>().AddAsync(entity);
        

        public async Task<IEnumerable<TEntity>> GetAllAsync()=>
            await _dbContext.Set<TEntity>().ToListAsync();

        public Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)=>
            await _dbContext.Set<TEntity>().FindAsync(id);

        public Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)=>
            _dbContext.Set<TEntity>().Remove(entity);
       

        public void Update(TEntity entity)
       => _dbContext.Set<TEntity>().Update(entity);
    }
}
