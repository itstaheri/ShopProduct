using Microsoft.EntityFrameworkCore.Storage;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IDbContextTransaction OpenTransaction();

        IQueryable<T> GetAll(bool asNoTrack = true);
        Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken,bool asNoTrack = true);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, bool asNoTrack = false, params Expression<Func<T, object>>[]? includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool asNoTrack = false, params Expression<Func<T, object>>[]? includes);
        T GetById(long id);
        Task<T> GetByIdAsync(long id, CancellationToken cancellationToken);
        bool Remove(long id);
        void Add(in T sender);
        Task<T> AddAsync( T sender, CancellationToken cancellationToken);
        void Update(in T sender);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken);
        long Save();
        Task<long> SaveAsync(CancellationToken cancellationToken);
        public IQueryable<T> Select(Expression<Func<T, bool>> predicate, bool asNoTrack = true);
        public Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool asNoTrack = true);
        public Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, Expression<Func<T, object>> include, bool asNoTrack = true);
        public void Dispose();

    }
}
