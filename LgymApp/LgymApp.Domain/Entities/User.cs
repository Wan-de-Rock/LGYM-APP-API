using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    public string NickName { get; set; }

    [EmailAddress, Required]
    public string Email { get; set; } // TODO: validate
    //public string HashedPassword { get; set; }
    //public string ProfilePicture { get; set; } //////

    [Required]
    public UserRolesEnum Role { get; private set; } = UserRolesEnum.Normal;

    public Plan? Plan { get; private set; }

    public string? ProfileRank { get; private set; }

    public int Elo { get; private set; } = 0;

    public User(
        string nickName,
        string email,
        UserRolesEnum userRole,
        Plan? plan,
        string profileRank,
        int elo
        )
    {
        Update(nickName, email, userRole, plan, profileRank, elo);
    }

    public void Update(
        string nickName,
        string email,
        UserRolesEnum userRole,
        Plan? plan,
        string profileRank,
        int elo)
    {
        SetNickName(nickName);
        SetEmail(email);
        SetUserRole(userRole);
        SetPlan(plan);
        SetProfileRank(profileRank);
        SetElo(elo);
    }

    public void SetNickName(string nickName)
        => NickName = !string.IsNullOrEmpty(nickName)
        ? nickName : throw new ArgumentNullException(nameof(nickName));

    public void SetEmail(string email) => Email = email;

    public void SetUserRole(UserRolesEnum role) => Role = role;

    public void SetPlan(Plan? plan) => Plan = plan;

    public void SetProfileRank(string rank) => ProfileRank = rank;

    public int SetElo(int elo)
        => Elo = elo >= 0
        ? elo : throw new ArgumentOutOfRangeException(nameof(elo));
}
