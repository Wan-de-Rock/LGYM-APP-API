using LgymApp.Api.Interfaces;

namespace LgymApp.Api.Endpoints.Auth;

public record RegisterUserRequest : IApiRequest
{
    public string Email { get; init; }
    public string Nickname { get; init; }
    public string Password { get; init; }
}

public record LoginUserRequest : IApiRequest
{
    public string NicknameOrEmail { get; init; }
    public string Password { get; init; }
}