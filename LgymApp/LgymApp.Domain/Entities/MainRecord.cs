using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class MainRecord : BaseEntity
{
    [Required, ForeignKey(nameof(Entities.User))]
    public User User { get; private set; }

    [Required, ForeignKey(nameof(Entities.Exercise))]
    public Exercise Exercise { get; private set; }

    [Required]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    [Required]
    public double Weight { get; private set; }

    [Required]
    public DateTime Date { get; private set; }

    public MainRecord(User? user, Exercise? exercise, WeightDataUnitsEnum weightUnit, double weight, DateTime date)
    {
        SetUser(user);
        SetExercise(exercise);

        Update(weightUnit, weight, date);
    }

    public void Update(WeightDataUnitsEnum weightUnit, double weight, DateTime date)
    {
        SetWeightUnit(weightUnit);
        SetWeight(weight);
        SetDate(date);
    }

    public void SetUser(User? user)
        => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetExercise(Exercise? exercise)
        => Exercise = exercise ?? throw new ArgumentNullException(nameof(exercise));

    public void SetWeightUnit(WeightDataUnitsEnum weightUnit)
        => WeightUnit = weightUnit;

    public void SetWeight(double weight)
        => Weight = weight >= 0 
        ? weight : throw new ArgumentOutOfRangeException(nameof(weight));

    public void SetDate(DateTime date)
        => Date = date;
}
