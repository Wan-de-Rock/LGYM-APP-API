using LgymApp.Domain.Entities;

namespace LgymApp.DataAccess.Interfaces;

public interface IUserRepository 
{
    public Task<User?> Get(Guid id);
    public Task<User?> GetByEmail(string email);
    public Task<Guid> Create(User user);
    public Task Update(User user);
    public Task Delete(User entity);
}