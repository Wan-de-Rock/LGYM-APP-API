using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using LgymApp.Domain.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents a user entity with properties and methods for managing user information.
/// </summary>
public class User : AuditableEntity
{
    /// <summary>
    /// The nickname of the user.
    /// </summary>
    [Required, StringLength(50)]
    public string NickName { get; private set; }

    /// <summary>
    /// The email address of the user.
    /// </summary>
    [Required, EmailAddress, StringLength(100)]
    public string Email { get; private set; } // TODO: validate
    //public string HashedPassword { get; set; }
    //public string ProfilePicture { get; set; } 

    /// <summary>
    /// The role of the user.
    /// </summary>
    [Required]
    public UserRolesEnum Role { get; private set; } = UserRolesEnum.Normal;

    /// <summary>
    /// The rank of the user based on their Elo score.
    /// </summary>
    public RanksEnum Rank => EloHelper.GetRank(Elo);

    /// <summary>
    /// The Elo score of the user.
    /// </summary>
    public int Elo { get; private set; } = EloHelper.EloRanks[RanksEnum.Junior_1].max; // TODO: Elo must be calculated based on the user's performance

    private User() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with the specified details.
    /// </summary>
    /// <param name="nickName">The nickname of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="userRole">The role of the user.</param>
    /// <param name="plan">The plan associated with the user.</param>
    /// <param name="elo">The Elo score of the user.</param>
    public User(
        string? nickName,
        string? email,
        UserRolesEnum userRole,
        int elo
        )
    {
        Update(nickName, email, userRole, elo);
    }

    /// <summary>
    /// Updates the user details with the specified information.
    /// </summary>
    /// <param name="nickName">The nickname of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="userRole">The role of the user.</param>
    /// <param name="plan">The plan associated with the user.</param>
    /// <param name="elo">The Elo score of the user.</param>
    public void Update(
        string? nickName,
        string? email,
        UserRolesEnum userRole,
        int elo)
    {
        SetNickName(nickName);
        SetEmail(email);
        SetUserRole(userRole);
        SetElo(elo);
    }

    /// <summary>
    /// Sets the nickname of the user.
    /// </summary>
    /// <param name="nickName">The nickname of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the nickname is null or empty.</exception>
    public void SetNickName(string? nickName)
        => NickName = !string.IsNullOrEmpty(nickName)
        ? nickName : throw new ArgumentNullException(nameof(nickName));

    /// <summary>
    /// Sets the email address of the user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when the email is null or empty.</exception>
    public void SetEmail(string? email)
        => Email = !string.IsNullOrEmpty(email)
        ? email : throw new ArgumentNullException(nameof(email));

    /// <summary>
    /// Sets the role of the user.
    /// </summary>
    /// <param name="role">The role of the user.</param>
    public void SetUserRole(UserRolesEnum role) => Role = role;

    /// <summary>
    /// Sets the Elo score of the user.
    /// </summary>
    /// <param name="elo">The Elo score of the user.</param>
    /// <returns>The updated Elo score.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the Elo score is less than 0.</exception>
    public int SetElo(int elo)
        => Elo = elo >= 0
        ? elo : throw new ArgumentOutOfRangeException(nameof(elo));
}
