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
        IQueryable<T> GetAll(bool asNoTrack = true);
        Task<IQueryable<T>> GetAllAsync(bool asNoTrack = true);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        bool Remove(int id);
        void Add(in T sender);
        Task AddAsync( T sender);
        void Update(in T sender);
        int Save();
        Task<int> SaveAsync();
        public IQueryable<T> Select(Expression<Func<T, bool>> predicate, bool asNoTrack = true);
        public Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate,bool asNoTrack = true);
        public Task<IQueryable<T>> SelectAsync(Expression<Func<T, bool>> predicate,Expression<Func<T,bool>> include, bool asNoTrack = true);
        public void Dispose();

    }
}
