using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Database;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IDisposable
    {

        private DbSet<T> _dbSet;
        private ShopDbContext _shopDbContext;
        public GenericRepository(ShopDbContext context)
        {
            _dbSet = context.Set<T>();
            _shopDbContext = context;
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _shopDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Add(in T sender)
        {
            if (sender is null)
                throw new ArgumentNullException(nameof(sender));

            _dbSet.Add(sender);
            Save();

        }

        public async Task AddAsync(T sender)
        {
           // IEnumerable<string> productnames = _shopDbContext.Provinces.Where(x=>x.Name == "a").Select(x=>x.Name);
           // IQueryable<string> province = _shopDbContext.Provinces.Where(x => x.Name == "a").Select(x => x.Name).AsQueryable();
            if (sender is null)
                throw new ArgumentNullException(nameof(sender));
            await _dbSet.AddAsync(sender);
            await SaveAsync();
        }

        public IQueryable<T> GetAll(bool asNoTrack = true)
        {
            if(asNoTrack)
                return _dbSet.AsNoTracking().AsQueryable();
            else
                return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<T>> GetAllAsync(bool asNoTrack = true)
        {
            if (asNoTrack)
                return  _dbSet.AsNoTracking().AsQueryable();
            else
                return _dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public bool Remove(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            return Convert.ToBoolean(Save());
            
        }

        public int Save()
        {
            return _shopDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _shopDbContext.SaveChangesAsync();

        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
            else
                return _dbSet.Where(predicate).AsQueryable();


        }

        public async Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
            else
                return _dbSet.Where(predicate).AsQueryable();

        }

        public async Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> include, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Include(include).AsSplitQuery().Where(predicate).AsQueryable();
            else
                return _dbSet.Include(include).AsSplitQuery().Where(predicate).AsQueryable();
        }

        public void Update(in T sender)
        {
            _dbSet.Update(sender);
            Save();
        }

        
    }
}
