namespace LgymApp.Application.Options;

public class AuthOptions
{
    public string Issuer { get; set; } 
    public string Audience { get; set; } 
    public string Secret { get; set; } 
    public int AccessTokenLifetimeInMinutes { get; set; } 
    public int RefreshTokenLifetimeInMinutes { get; set; } 
}