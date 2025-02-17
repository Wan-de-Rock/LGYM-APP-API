using LgymApp.Application.Dtos;
using LgymApp.Application.Helpers;
using LgymApp.Application.Interfaces;
using LgymApp.Application.Options;
using LgymApp.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LgymApp.Api.Endpoints.Auth;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("auth")
            .WithOpenApi()
            ;
        
        group.MapPost("register", Register);
        group.MapPost("login", Login)
            .WithSummary("Login user")
            ;

        return app;
    }
    
    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest registerUserRequest,
        IUserService userService,
        IOptions<AuthOptions> authOptions
        )
    {
        var userDto = new UserDto // TODO: Use mapper
        {
            Nickname = registerUserRequest.Nickname,
            Email = registerUserRequest.Email,
            Password = registerUserRequest.Password
        };
        var user = await userService.Create(userDto);
        
        var token = AuthHelper.GenerateJwtToken(user, authOptions.Value);
        return Results.Ok(token);
    }
    
    private static async Task<IResult> Login(
        [FromBody] LoginUserRequest request, 
        IOptions<AuthOptions> authOptions,
        AppDbContext dbContext)
    {
        var user = await dbContext.Set<Domain.Entities.User>().FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null || !AuthHelper.VerifyPasswordHash(request.Password, user.HashedPassword))
        {
            return Results.Unauthorized();
        }

        var token = AuthHelper.GenerateJwtToken(user, authOptions.Value);
        return Results.Ok(token);
    }
}
