
using System;
using System.Threading.Tasks;

namespace XNerd.Ecommerce.Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}