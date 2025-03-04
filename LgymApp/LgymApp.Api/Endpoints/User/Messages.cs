using LgymApp.Api.Interfaces;

namespace LgymApp.Api.Endpoints.User;

public record CreateUserRequest: IApiRequest
{
    public string Nickname { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}

public record UpdateUserRequest: CreateUserRequest, IApiRequest
{
    public Guid Id { get; init; }
}