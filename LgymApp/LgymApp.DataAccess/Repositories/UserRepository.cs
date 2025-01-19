using LgymApp.DataAccess.Interfaces;
using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.DataAccess.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> Get(Guid id)
    {
        return await context.Set<User>().FindAsync(id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await context.Set<User>().SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Guid> Create(User entity)
    {
        await context.Set<User>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Update(User entity)
    {
        //await context.Set<User>().Where(x => x.Id == user.Id).ExecuteUpdateAsync();
        await context.Set<User>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(User entity)
    {
        //context.Set<User>().Where(x => x.Id == user.Id).ExecuteDeleteAsync();
        await context.Set<User>().AddAsync(entity);
        entity.SetDeleted();
        await context.SaveChangesAsync();
    }
}