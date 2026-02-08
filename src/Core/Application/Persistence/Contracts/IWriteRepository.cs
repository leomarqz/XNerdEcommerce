

using System.Collections.Generic;

namespace XNerd.Ecommerce.Application.Persistence.Contracts
{
    public interface IWriteRepository<T> where T : class
    {
            void AddEntity(T entity);
            void UpdateEntity(T entity);
            void DeleteEntity(T entity);

            void AddRange(List<T> entities);
            void DeleteRange(IReadOnlyList<T> entities);
    }
}