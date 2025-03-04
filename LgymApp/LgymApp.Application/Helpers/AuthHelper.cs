using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LgymApp.Application.Options;
using LgymApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LgymApp.Application.Helpers;

public static class AuthHelper 
{
    /*
        Рекомендуемая минимальная длина пароля зависит от того, используете ли вы только случайные символы или обычные слова:
        Тип пароля	Минимальная длина (рекомендации OWASP, NIST)
        Только цифры	12+ символов (например, 486920482761)
        Цифры + буквы	10+ символов (например, 4xG8mT2yZ3)
        Буквы, цифры, спецсимволы	8+ символов (например, A3$dP9@!)
        Произвольная фраза	4+ слова (например, purple horse battery staple)
     */
    
    private const int SaltSize = 16; // 16 байт = 128 бит
    private const int HashSize = 32; // 32 байт = 256 бит
    private const int Iterations = 100_000; // Количество итераций PBKDF2

    /// <summary>
    /// Хеширует пароль с солью, используя PBKDF2-HMACSHA512.
    /// </summary>
    public static string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt); // Генерация случайной соли

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
        var hash = pbkdf2.GetBytes(HashSize); // Получение хэша пароля

        // Склеиваем соль и хэш, кодируем в Base64
        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
        
        return Convert.ToBase64String(hashBytes);
    }

    /// <summary>
    /// Проверяет, соответствует ли пароль сохраненному хэшу.
    /// </summary>
    public static bool VerifyPassword(string password, string storedHash)
    {
        var hashBytes = Convert.FromBase64String(storedHash);

        if (hashBytes.Length != SaltSize + HashSize)
            return false; // Неверный формат хэша

        // Извлекаем соль и хэш из сохраненного значения
        var salt = new byte[SaltSize];
        var storedPasswordHash = new byte[HashSize];

        Array.Copy(hashBytes, 0, salt, 0, SaltSize);
        Array.Copy(hashBytes, SaltSize, storedPasswordHash, 0, HashSize);

        // Хешируем введенный пароль с той же солью
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
        var computedHash = pbkdf2.GetBytes(HashSize);

        // Сравниваем хэши
        return computedHash.SequenceEqual(storedPasswordHash);
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