using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LgymApp.Domain.Entities;

public class Measurement : BaseEntity
{
    [Required, ForeignKey(nameof(LgymApp.Domain.Entities.User))]
    public User User { get; private set; }

    [Required]
    public BodyPartsEnum BodyPart { get; private set; }

    [Required]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    [Required]
    public double Weight { get; private set; }

    public Measurement(User user, BodyPartsEnum bodyPart, WeightDataUnitsEnum weightUnit, double weight)
    {
        SetUser(user);
        Update(bodyPart, weightUnit, weight);
    }

    public void Update(BodyPartsEnum bodyPart, WeightDataUnitsEnum weightUnit, double weight)
    {
        SetBodyPart(bodyPart);
        SetWeightUnit(weightUnit);
        SetWeight(weight);
    }

    public void SetUser(User? user)
        => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetBodyPart(BodyPartsEnum bodyPart)
        => BodyPart = bodyPart;

    public void SetWeightUnit(WeightDataUnitsEnum weightUnit)
        => WeightUnit = weightUnit;

    public void SetWeight(double weight)
        => Weight = weight >= 0
        ? weight : throw new ArgumentOutOfRangeException(nameof(weight));
}
