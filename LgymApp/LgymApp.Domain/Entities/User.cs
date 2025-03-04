using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using LgymApp.Domain.Interfaces;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents a user entity with properties and methods for managing user information.
/// </summary>
public class User : BaseEntity<User>, ISoftDeletable
{
    public new static string TableName => "users";

    /// <summary>
    /// The nickname of the user.
    /// </summary>
    public string Nickname { get; private set; }

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public string Email { get; private set; } 
    
    /// <summary>
    /// The hashed password of the user.
    /// </summary>
    public string HashedPassword { get; private set; }
    //public string ProfilePicture { get; set; } 
    
    public DateTime? DeletedAt { get; private set; }

    /// <summary>
    /// The rank of the user based on their Elo score.
    /// </summary>
    //public RanksEnum Rank => EloHelper.GetRank(Elo);

    /// <summary>
    /// The Elo score of the user.
    /// </summary>
    //public int Elo { get; private set; } = EloHelper.EloRanks[RanksEnum.Junior_1].max; // TODO: Elo must be calculated based on the user's performance

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with the specified details.
    /// </summary>
    /// <param name="nickname">The nickname of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="hashedPassword">The hashed password of the user.</param>
    public User(
        string? nickname,
        string? email,
        string hashedPassword
        )
    {
        Update(nickname, email, hashedPassword);
    }

    /// <summary>
    /// Updates the user details with the specified information.
    /// </summary>
    /// <param name="nickname">The nickname of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="hashedPassword">The hashed password of the user.</param>
    public void Update(
        string? nickname,
        string? email,
        string hashedPassword)
    {
        SetNickname(nickname);
        SetEmail(email);
        SetHashedPassword(hashedPassword);
    }

    /// <summary>
    /// Sets the nickname of the user.
    /// </summary>
    /// <param name="nickname">The nickname of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the nickname is null or empty.</exception>
    public void SetNickname(string? nickname)
        => Nickname = !string.IsNullOrEmpty(nickname)
        ? nickname : throw new ArgumentNullException(nameof(nickname));
    
    /// <summary>
    /// Sets the hashed password of the user.
    /// </summary>
    /// <param name="hashedPassword">The hashed password of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the hashed password is null or empty.</exception>
    public void SetHashedPassword(string hashedPassword)
        => HashedPassword = !string.IsNullOrEmpty(hashedPassword)
            ? hashedPassword : throw new ArgumentNullException(nameof(hashedPassword));

    /// <summary>
    /// Sets the email address of the user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the email is null or empty.</exception>
    public void SetEmail(string? email)
        => Email = !string.IsNullOrEmpty(email)
        ? email : throw new ArgumentNullException(nameof(email));
}
