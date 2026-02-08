

using XNerd.Ecommerce.Application.Persistence.Contracts;

namespace XNerd.Ecommerce.Application.Persistence
{
    public interface IRepository<T> :
        IReadRepository<T>,
        IWriteRepository<T>,
        ICRUDAsync<T>
        where T : class
    {}
    
}