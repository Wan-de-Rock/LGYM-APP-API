using LgymApp.Api.Interfaces;
using LgymApp.Application.Dtos;
using LgymApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LgymApp.Api.Endpoints.User;

public class UserEndpoints : IEndpointDefinition
{
    public WebApplication DefineEndpoints(WebApplication app)
    {
        var group = app.MapGroup("users")
            .WithOpenApi()
            .RequireAuthorization()
            ;

        group.MapGet("{id}", Get);
        return app;
    }
    
    private static async Task<IResult> Get(
        Guid id,
        IUserService userService
        )
    {
        var user = await userService.Get(id);
        return user == null ? Results.NotFound() : Results.Ok(user);
    }
    
   
    private static async Task<IResult> Create(
        [FromBody] UserDto userDto,
        IUserService userService
        )
    {
        var id = await userService.Create(userDto);
        return Results.Ok(id);
    }
    
    private static async Task<IResult> Update(
        Guid id,
        [FromBody] UserDto userDto,
        IUserService userService
        )
    {
        userDto.Id = id;
        await userService.Update(userDto);
        return Results.Ok();
    }
}