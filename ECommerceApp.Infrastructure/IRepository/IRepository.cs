﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        Task DeleteAsync(int id);
        void DeleteRangeAsync(IEnumerable<T> entities);
    }
}
