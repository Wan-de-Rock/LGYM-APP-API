namespace LgymApp.Api.Endpoints.Auth;

public record RegisterUserRequest
{
    public string Email { get; init; }
    public string Nickname { get; init; }
    public string Password { get; init; }
}

public record LoginUserRequest : RegisterUserRequest {}
