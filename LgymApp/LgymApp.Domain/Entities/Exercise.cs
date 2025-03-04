using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using LgymApp.Domain.Interfaces;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents an exercise entity.
/// </summary>
public class Exercise : BaseEntity<Exercise>, ISoftDeletable
{
    public new const string TableName = "exercises";
    
    /// <summary>
    /// Name of the exercise.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Body part targeted by the exercise.
    /// </summary>
    public BodyPartsEnum BodyPart { get; private set; }

    /// <summary>
    /// The user who added the exercise. If the user field is missing, 
    /// it means that this is a global exercise visible to all users 
    /// if not, this is a private exercise for the user who added It
    /// </summary>
    public User? User { get; private set; }

    /// <summary>
    /// Description of the exercise.
    /// </summary>
    public string? Description { get; private set; }
    
    public DateTime? DeletedAt { get; private set; } 

    //public string? ImageUrl { get; set; }
    //public string? VideoUrl { get; set; }
    //public string? Equipment { get; set; }
    //public string? Difficulty { get; set; }
    //public string? ExerciseType { get; set; }

    private Exercise() { }

    public Exercise(string name, BodyPartsEnum bodyPart, string description) => Update(name, bodyPart, description);

    public Exercise(string name, BodyPartsEnum bodyPart, string description, User user) : this(name, bodyPart, description)
    {
        SetUser(user);
    }

    public void Update(string name, BodyPartsEnum bodyPart, string description)
    {
        SetName(name);
        SetBodyPart(bodyPart);
        SetDescription(description);
    }

    public void SetName(string name) 
        => Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name));

    public void SetBodyPart(BodyPartsEnum bodyPart) => BodyPart = bodyPart;

    public void SetDescription(string description) 
        => Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentNullException(nameof(description));

    public void SetUser(User user) => User = user ?? throw new ArgumentNullException(nameof(user));
}
