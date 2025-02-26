using LgymApp.Api.Interfaces;
using LgymApp.Application.Dtos;
using LgymApp.Application.Helpers;
using LgymApp.Application.Interfaces;
using LgymApp.Application.Options;
using LgymApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LgymApp.Api.Endpoints.Auth;

public sealed class AuthEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder
                .MapGroup("auth")
                .WithTags("Auth")
                .WithOpenApi()
            ;

        group.MapPost("register", Register);
        group.MapPost("login", Login)
            .WithSummary("Login user")
            ;
    }

    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest registerUserRequest,
        UserService userService,
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
        UserService userService)
    {
        var user = await userService.GetByNicknameOrEmail(request.NicknameOrEmail);
        if (user == null || !AuthHelper.VerifyPasswordHash(request.Password, user.HashedPassword))
        {
            return Results.Unauthorized();
        }

        var token = AuthHelper.GenerateJwtToken(user, authOptions.Value);
        return Results.Ok(token);
    }
}