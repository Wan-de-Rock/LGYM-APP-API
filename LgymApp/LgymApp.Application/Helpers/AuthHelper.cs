using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LgymApp.Application.Options;
using LgymApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LgymApp.Application.Helpers;

public static class AuthHelper // TODO: Add salt to password hashing
{
    public static string HashPassword(string password)
    {
        using var hmac = new HMACSHA512();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        return Convert.ToBase64String(hmac.ComputeHash(passwordBytes));
    }
    
    public static bool VerifyPasswordHash(string password, string passwordHash)
    {
        using var hmac = new HMACSHA512(Convert.FromBase64String(passwordHash));
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var computedHash = hmac.ComputeHash(passwordBytes);
        return computedHash.SequenceEqual(Convert.FromBase64String(passwordHash));
    }
    
    public static string GenerateJwtToken(User user, AuthOptions authOptions)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(authOptions.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([new Claim(nameof(User.Id), user.Id.ToString())]),
            Issuer = authOptions.Issuer,
            Audience = authOptions.Audience,
            IssuedAt = DateTime.UtcNow,
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(authOptions.AccessTokenLifetimeInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}