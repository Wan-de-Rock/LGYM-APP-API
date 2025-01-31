using LgymApp.Application.Helpers;
using LgymApp.Application.Options;
using LgymApp.DataAccess;
using LgymApp.Domain.Entities;
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
            //.RequireAuthorization()
            ;
        
        group.MapPost("register", Register);
        group.MapPost("login", Login)
            .WithSummary("Login user")
            ;

        return app;
    }
    
    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest registerUserRequest,
        IOptions<AuthOptions> authOptions
        )
    {
        var user = new User(registerUserRequest.Nickname, registerUserRequest.Email, AuthHelper.HashPassword(registerUserRequest.Password));
        
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
