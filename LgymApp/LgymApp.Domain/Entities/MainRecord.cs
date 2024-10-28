using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

/// <summary>
/// The best result of the exercise.
/// </summary>
public class MainRecord : BaseEntity
{
    /// <summary>
    /// User associated with the main record.
    /// </summary>
    [Required, ForeignKey(nameof(Entities.User))]
    public User User { get; private set; }

    /// <summary>
    /// Exercise associated with the main record.
    /// </summary>
    [Required, ForeignKey(nameof(Entities.Exercise))]
    public Exercise Exercise { get; private set; }

    /// <summary>
    /// Weight unit of the main record.
    /// </summary>
    [Required]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    /// <summary>
    /// Weight of the main record.
    /// </summary>
    [Required]
    public double Weight { get; private set; }

    /// <summary>
    /// Date of the main record.
    /// </summary>
    [Required]
    public DateTime Date { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainRecord"/> class.
    /// </summary>
    /// <param name="user">The user associated with the main record.</param>
    /// <param name="exercise">The exercise associated with the main record.</param>
    /// <param name="weightUnit">The weight unit of the main record.</param>
    /// <param name="weight">The weight of the main record.</param>
    /// <param name="date">The date of the main record.</param>
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
