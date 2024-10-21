using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class Plan : BaseEntity
{
    [Required]
    public string Name { get; private set; }

    [Required, ForeignKey(nameof(Entities.User))]
    public User User { get; private set; }

    [Required]
    public int NumberOfTrainingDays { get; private set; }

    public Plan(string name, int numberOfTrainingDays, User user)
    {
        SetUser(user);
        Update(name, numberOfTrainingDays);
    }

    public void Update(string name, int numberOfTrainingDays)
    {
        SetName(name);
        SetNumberOfTrainingDays(numberOfTrainingDays);
    }

    public void SetName(string name)
        => Name = !string.IsNullOrEmpty(name) 
        ? name : throw new ArgumentNullException(nameof(name));

    public void SetUser(User? user)
    => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetNumberOfTrainingDays(int numberOfTrainingDays)
        => NumberOfTrainingDays = numberOfTrainingDays > 0
        ? numberOfTrainingDays
        : throw new ArgumentOutOfRangeException(nameof(numberOfTrainingDays));
}
