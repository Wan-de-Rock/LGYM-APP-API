using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents an exercise score entity.
/// </summary>
public class ExerciseScore : AuditableEntity
{
    /// <summary>
    /// Exercise associated with the score.
    /// </summary>
    [Required]
    public Exercise Exercise { get; private set; }

    /// <summary>
    /// User associated with the score.
    /// </summary>
    [Required]
    public User User { get; private set; }

    /// <summary>
    /// Training associated with the score.
    /// </summary>
    [Required]
    public TrainingResult Training { get; private set; }

    /// <summary>
    /// Number of repeats in current series.
    /// </summary>
    [Required] // TODO change to int and implement enum for partial repeats
    public double Repeats { get; private set; }

    /// <summary>
    /// Series number.
    /// </summary>
    [Required]
    public int Series { get; private set; }

    /// <summary>
    /// Weight for the exercise score.
    /// </summary>
    [Required]
    public double Weight { get; private set; }

    /// <summary>
    /// Weight unit for the exercise score.
    /// </summary>
    [Required, EnumDataType(typeof(WeightDataUnitsEnum))]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    public ExerciseScore(Exercise? exercise, User? user, TrainingResult? training, double repeats, int series, double weight, WeightDataUnitsEnum weightUnit)
    {
        SetExercise(exercise);
        SetUser(user);
        SetTraining(training);

        Update(repeats, series, weight, weightUnit);
    }

    public void Update(double repeats, int series, double weight, WeightDataUnitsEnum weightUnit)
    {
        SetRepeats(repeats);
        SetSeries(series);
        SetWeight(weight);
        SetWeightUnit(weightUnit);
    }

    public void SetExercise(Exercise? exercise) 
        => Exercise = exercise ?? throw new ArgumentNullException(nameof(exercise));
    
    public void SetUser(User? user) 
        => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetTraining(TrainingResult? training) 
        => Training = training ?? throw new ArgumentNullException(nameof(training));

    public void SetRepeats(double repeats) 
        => Repeats = repeats >= 0 ? repeats : throw new ArgumentOutOfRangeException(nameof(repeats));

    public void SetSeries(int series)
        => Series = series > 0 ? series : throw new ArgumentOutOfRangeException(nameof(series));

    // TODO Do przegadania, bo co np z ćwiczeniami jak podciaganie ktore dotychczas dawalismy -35kg np, ale moze warto sie pozbyc tego minusa
    public void SetWeight(double weight)
        => Weight = weight >= 0 ? weight : throw new ArgumentOutOfRangeException(nameof(weight));

    public void SetWeightUnit(WeightDataUnitsEnum weightUnit) => WeightUnit = weightUnit;
}
