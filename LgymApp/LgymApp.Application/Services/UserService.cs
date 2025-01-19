using LgymApp.Application.Dtos;
using LgymApp.Application.Interfaces;

namespace LgymApp.Application.Services;

public class UserService : IUserService
{
    public Task<UserDto> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}