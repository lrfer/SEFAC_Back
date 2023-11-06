using Microsoft.EntityFrameworkCore;
using SEFAC.Domain.Entities;
using SEFAC.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace SEFAC.Infrastructure.Persistence.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _repository;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _repository = context.Set<TEntity>();
        }

        public async Task Delete(int id)
        {
            var result = await this.GetById(id);
            if (result is not null)
                _repository.Remove(result);

            _context.SaveChanges();
        }

        public async virtual Task<TEntity> Insert(TEntity entity)
        {
            var result = await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            var result = await this.GetById(entity.Id);
            if (result is not null)
                _repository.Update(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<TEntity> GetById(int id) => await _repository.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filtro = null)
        {
            if (filtro is null)
                return await _repository.AsQueryable().ToListAsync();

            return await _repository.AsQueryable().Where(filtro).ToListAsync();
        }

    }
}
