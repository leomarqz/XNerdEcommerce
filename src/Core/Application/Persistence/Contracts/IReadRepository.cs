
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XNerd.Ecommerce.Application.Persistence.Contracts
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(
                                    Expression<Func<T, bool>>? predicate,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
                                    string? includeString,
                                    bool disableTracking = true
                                );
        Task<IReadOnlyList<T>> GetAsync(
                                    Expression<Func<T, bool>>? predicate,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    List<Expression<Func<T, object>>>? includes = null,
                                    bool disableTracking = true
                                );

        Task<T> GetEntityAsync(
                            Expression<Func<T, bool>>? predicate,
                            List<Expression<Func<T, object>>>? includes = null,
                            bool disableTracking = true
                        );

        // Task<T> GetByIdAsync(int id);
        // Task<T> AddAsync(T entity);
        // Task<T> UpdateAsync(T entity);
        // Task DeleteAsync(T entity);

    }
}