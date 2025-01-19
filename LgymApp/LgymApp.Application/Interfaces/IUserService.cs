using LgymApp.Application.Dtos;

namespace LgymApp.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> Get(Guid id);
    Task<UserDto> GetByEmail(string email);
    Task<Guid> Create(UserDto userDto);
    Task Update(UserDto userDto);
    Task Delete(Guid id);
}