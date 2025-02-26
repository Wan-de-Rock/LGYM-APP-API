using LgymApp.Api.Interfaces;
using LgymApp.Application.Dtos;
using LgymApp.Application.Helpers;
using LgymApp.Application.Interfaces;
using LgymApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LgymApp.Api.Endpoints.User;

public sealed class UserEndpoints : IEndpointDefinition
{
    public void DefineEndpoints(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("users")
                .WithTags("Users")
                .WithOpenApi()
                .RequireAuthorization()
            ;

        group.MapGet("{id}", Get);
        group.MapPost("", Create);
        group.MapPut("", Update);
        group.MapDelete("{id}", Delete);
    }

    private static async Task<IResult> Get(
        Guid id,
        UserService userService
    )
    {
        var user = await userService.Get(id);
        return user == null ? Results.NotFound() : Results.Ok(user);
    }


    private static async Task<IResult> Create(
        [FromBody] CreateUserRequest createUserRequest,
        UserService userService
    )
    {
        var userDto = new UserDto //TODO: Use AutoMapper
        {
            Nickname = createUserRequest.Nickname,
            Email = createUserRequest.Email,
            Password = AuthHelper.HashPassword(createUserRequest.Password)
        };

        var id = await userService.Create(userDto);
        return Results.Ok(id);
    }

    private static async Task<IResult> Update(
        [FromBody] UpdateUserRequest updateUserRequest,
        UserService userService
    )
    {
        var userDto = new UserDto
        {
            Id = updateUserRequest.Id,
            Nickname = updateUserRequest.Nickname,
            Email = updateUserRequest.Email,
            Password = AuthHelper.HashPassword(updateUserRequest.Password)
        };

        await userService.Update(userDto);
        return Results.Ok();
    }

    private static async Task<IResult> Delete(
        Guid id,
        UserService userService
    )
    {
        await userService.Delete(id);
        return Results.Ok();
    }
}