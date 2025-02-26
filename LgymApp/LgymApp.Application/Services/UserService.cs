using LgymApp.Application.Dtos;
using LgymApp.Application.Helpers;
using LgymApp.Application.Interfaces;
using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LgymApp.Application.Services;

public class UserService(AppDbContext context) : IScopedService
{
    public async Task<User?> Get(Guid id)
    {
        return await context.Set<User>().FindAsync(id);
    }
    
    public async Task<User?> GetByNicknameOrEmail(string nicknameOrEmail)
    {
        return await context.Set<User>()
            .FirstOrDefaultAsync(x => x.Email == nicknameOrEmail 
                                      || x.Nickname == nicknameOrEmail);
    }

    public async Task<User> Create(UserDto userDto)
    {
        var hashedPassword = AuthHelper.HashPassword(userDto.Password);
        var user = new User(userDto.Nickname, userDto.Email, hashedPassword);
        await context.Set<User>().AddAsync(user);  
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> Update(UserDto userDto)
    {
        var hashedPassword = AuthHelper.HashPassword(userDto.Password);
        var user = await context.Set<User>().FindAsync(userDto.Id);
        if (user is null) return null;
        
        user.Update(userDto.Nickname, userDto.Email, hashedPassword);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task Delete(Guid id)
    {
        var user = await context.Set<User>().FindAsync(id);
        if (user is null) return;
        
        context.Set<User>().Remove(user);
        await context.SaveChangesAsync();
    }
}