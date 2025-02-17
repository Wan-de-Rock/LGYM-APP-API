using LgymApp.Application.Dtos;
using LgymApp.Domain.Entities;

namespace LgymApp.Application.Interfaces;

public interface IUserService
{
    Task<User?> Get(Guid id);
    Task<User> Create(UserDto userDto);
    Task Update(UserDto userDto);
    Task Delete(Guid id);
}