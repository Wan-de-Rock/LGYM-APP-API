using LgymApp.Application.Dtos;
using LgymApp.Application.Helpers;
using LgymApp.Application.Interfaces;
using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Application.Services;

public class UserService(AppDbContext context) : IUserService
{
    public async Task<User?> Get(Guid id)
    {
        return await context.Set<User>().FindAsync(id);
    }

    public async Task<User> Create(UserDto userDto)
    {
        var hashedPassword = AuthHelper.HashPassword(userDto.Password);
        var user = new User(userDto.Nickname, userDto.Email, hashedPassword);
        await context.Set<User>().AddAsync(user);  
        await context.SaveChangesAsync();
        return user;
    }

    public Task Update(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        await context.Set<User>().ExecuteDeleteAsync()
    }
}