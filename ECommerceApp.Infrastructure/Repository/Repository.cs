using ECommerceApp.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<T> _db;
        public Repository(ECommerceDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task DeleteAsync(int id)
        {
            _db.Remove(await _db.FindAsync(id));
        }

        public void DeleteRangeAsync(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public IQueryable<T> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach(var property in includes)
                {
                    query = query.Include(property);
                }
            }
            return await _db.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void UpdateAsync(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
