using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class Exercise : BaseEntity
{
    [Required]
    public string Name { get; private set; }

    [EnumDataType(typeof(BodyPartsEnum))]
    public BodyPartsEnum BodyPart { get; private set; }

    [ForeignKey(nameof(LgymApp.Domain.Entities.User))]
    public User? User { get; private set; }

    public string? Description { get; private set; }

    //public string? ImageUrl { get; set; }
    //public string? VideoUrl { get; set; }
    //public string? Equipment { get; set; }
    //public string? Difficulty { get; set; }
    //public string? ExerciseType { get; set; }

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
