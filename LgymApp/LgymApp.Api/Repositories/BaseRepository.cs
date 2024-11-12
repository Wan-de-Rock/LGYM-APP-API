using LgymApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Api.Repositories;

public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<Guid> CreateAsync(TEntity entity)
    {
        var entityEntry = await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entityEntry.Entity.Id;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        entity.SetDeleted();
        await _context.SaveChangesAsync();
    }
}
