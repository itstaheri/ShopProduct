using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Application.Interfaces.Database;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : BaseEntity
    {

        protected DbSet<T> _dbSet;
        protected ShopDbContext _shopDbContext;
        public GenericRepository(ShopDbContext context)
        {
            _shopDbContext = context;
            _dbSet = _shopDbContext.Set<T>();
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

        public async Task<T> AddAsync(T sender, CancellationToken cancellationToken)
        {
            // IEnumerable<string> productnames = _shopDbContext.Provinces.Where(x=>x.Name == "a").Select(x=>x.Name);
            // IQueryable<string> province = _shopDbContext.Provinces.Where(x => x.Name == "a").Select(x => x.Name).AsQueryable();
            if (sender is null)
                throw new ArgumentNullException(nameof(sender));

            var result = await _dbSet.AddAsync(sender, cancellationToken);
            await SaveAsync(cancellationToken);

            return result.Entity;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }
        public IQueryable<T> GetAll(bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().AsQueryable();
            else
                return _dbSet.AsQueryable();
        }

        public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().AsQueryable();
            else
                return _dbSet.AsQueryable();
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public bool Remove(long id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            return Convert.ToBoolean(Save());

        }

        public long Save()
        {
            return _shopDbContext.SaveChanges();
        }

        public async Task<long> SaveAsync(CancellationToken cancellationToken)
        {
            return await _shopDbContext.SaveChangesAsync(cancellationToken);

        }

        public IQueryable<T> Select(Expression<Func<T, bool>> predicate, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
            else
                return _dbSet.Where(predicate).AsQueryable();


        }

        public async Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
            else
                return _dbSet.Where(predicate).AsQueryable();

        }

        public async Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, Expression<Func<T, object>> include, bool asNoTrack = true)
        {
            if (asNoTrack)
                return _dbSet.AsNoTracking().Include(include).AsSplitQuery().Where(predicate).OrderByDescending(x => x.CreatedAt).AsQueryable();
            else
                return _dbSet.Include(include).AsSplitQuery().Where(predicate).OrderByDescending(x => x.CreatedAt).AsQueryable();
        }

        public void Update(in T sender)
        {
            _dbSet.Update(sender);
            Save();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool asNoTrack = false, params Expression<Func<T, object>>[]? includes)
        {
            var entity = _dbSet.AsQueryable();

            if (asNoTrack)
                entity.AsNoTracking();


            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entity = includes.Aggregate(entity,
                  (current, include) => current.Include(include));
                }
            }
            //entity = entity.Where(predicate).AsQueryable();

            return await entity.FirstOrDefaultAsync(predicate, cancellationToken);

        }

        public IDbContextTransaction OpenTransaction()
        {
            return _shopDbContext.Database.BeginTransaction();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public T Get(Expression<Func<T, bool>> predicate, bool asNoTrack = false, params Expression<Func<T, object>>[]? includes)
        {
            var entity = _dbSet.AsQueryable();

            if (asNoTrack)
                entity.AsNoTracking();


            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entity = includes.Aggregate(entity,
                  (current, include) => current.Include(include));
                }
            }
            //entity = entity.Where(predicate).AsQueryable();

            return  entity.FirstOrDefault(predicate);

        }


        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public async Task AddRangeAsync(IEnumerable<T> sender, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(sender);
            await SaveAsync(cancellationToken);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
