using ECommerceApp.Core.Interface;
using ECommerceApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApp.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        public Repository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
