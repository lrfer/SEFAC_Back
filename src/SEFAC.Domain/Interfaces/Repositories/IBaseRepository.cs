using SEFAC.Domain.Entities;
using System.Linq.Expressions;

namespace SEFAC.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filtro = null);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
