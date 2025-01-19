using System.ComponentModel.DataAnnotations;
using LgymApp.Application.Helpers;
using LgymApp.Application.Options;
using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LgymApp.Api.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);

        return app;
    }
    
    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest request,
        IOptions<AuthOptions> authOptions
        )
    {
        var user = new User(request.Nickname, request.Email, AuthHelper.HashPassword(request.Password));
        
        var token = AuthHelper.GenerateJwtToken(user, authOptions.Value);
        return Results.Ok(token);
    }
    
    private static async Task<IResult> Login(
        [FromBody] LoginUserRequest request, 
        IOptions<AuthOptions> authOptions,
        AppDbContext dbContext)
    {
        var user = await dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null || !AuthHelper.VerifyPasswordHash(request.Password, user.HashedPassword))
        {
            return Results.Unauthorized();
        }

        var token = AuthHelper.GenerateJwtToken(user, authOptions.Value);
        return Results.Ok(token);
    }
}

public record RegisterUserRequest(
    [Required] string Nickname,
    [Required] string Email,
    [Required] string Password
    );
public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password
    );