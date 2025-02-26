using LgymApp.Application.Dtos;
using LgymApp.Domain.Entities;

namespace LgymApp.Application.Interfaces;

public interface IUserService
{
    Task<User?> Get(Guid id);
    Task<User?> GetByNicknameOrEmail(string nicknameOrEmail);
    Task<User> Create(UserDto userDto);
    Task<User?> Update(UserDto userDto);
    Task Delete(Guid id);
}