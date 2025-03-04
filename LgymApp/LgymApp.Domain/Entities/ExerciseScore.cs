using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents an exercise score entity.
/// </summary>
public class ExerciseScore : BaseEntity<ExerciseScore>
{
    public new const string TableName = "exercise_scores";
    
    /// <summary>
    /// Exercise associated with the score.
    /// </summary>
    public Exercise Exercise { get; private set; }

    /// <summary>
    /// The unique identifier of the exercise associated with the score.
    /// </summary>
    public Guid ExerciseId { get; private set; }

    /// <summary>
    /// User associated with the score.
    /// </summary>
    public User User { get; private set; }

    /// <summary>
    /// The unique identifier of the user associated with the score.
    /// </summary>
    public Guid UserId { get; private set; }
    
    /// <summary>
    /// Training associated with the score.
    /// </summary>
    public TrainingResult TrainingResult { get; private set; }
    
    /// <summary>
    /// The unique identifier of the training result associated with the score.
    /// </summary>
    public Guid TrainingResultId { get; private set; }

    /// <summary>
    /// Number of repeats in current series.
    /// </summary>
    public double Repeats { get; private set; }// TODO change to int and implement enum for partial repeats

    /// <summary>
    /// Series number.
    /// </summary>
    public int Series { get; private set; }

    /// <summary>
    /// Weight for the exercise score.
    /// </summary>
    public double Weight { get; private set; }

    /// <summary>
    /// Weight unit for the exercise score.
    /// </summary>
    [EnumDataType(typeof(WeightDataUnitsEnum))]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    private ExerciseScore() { }

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
        => TrainingResult = training ?? throw new ArgumentNullException(nameof(training));

    public void SetRepeats(double repeats) 
        => Repeats = repeats >= 0 ? repeats : throw new ArgumentOutOfRangeException(nameof(repeats));

    public void SetSeries(int series)
        => Series = series > 0 ? series : throw new ArgumentOutOfRangeException(nameof(series));

    // TODO Do przegadania, bo co np z ćwiczeniami jak podciaganie ktore dotychczas dawalismy -35kg np, ale moze warto sie pozbyc tego minusa
    public void SetWeight(double weight)
        => Weight = weight >= 0 ? weight : throw new ArgumentOutOfRangeException(nameof(weight));

    public void SetWeightUnit(WeightDataUnitsEnum weightUnit) => WeightUnit = weightUnit;
}
