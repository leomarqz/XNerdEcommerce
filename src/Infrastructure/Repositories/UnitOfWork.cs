
using System;
using System.Collections;
using System.Threading.Tasks;

using XNerd.Ecommerce.Application.Persistence;
using XNerd.Ecommerce.Infrastructure.Persistence;

namespace XNerd.Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        private Hashtable? _repositories;

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();

            }catch(Exception e)
            {
                throw new Exception($"Error al guardar los cambios en la base de datos: {e.Message}", e);
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            // Almacen de repositorios
            if(_repositories == null)
                _repositories = new Hashtable();

            // Entidad de la cual requerimos el repositorio
            var type = typeof(TEntity).Name;

            // Si no existe el repositorio, se crea una instancia y se almacena en el hashtable
            if( !_repositories.ContainsKey(type) )
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType( typeof(TEntity) ), 
                    _context
                );
                _repositories.Add(type, repositoryInstance);
            }

            // Retornamos el repositorio
            return (IRepository<TEntity>) _repositories[type]!;
        }
    }
}