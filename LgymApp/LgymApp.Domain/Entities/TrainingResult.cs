using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents a training result entity.
/// </summary>
public class TrainingResult : BaseEntity
{
    /// <summary>
    /// The user associated with the training result.
    /// </summary>
    [Required]
    public User User { get; private set; }

    /// <summary>
    /// The training plan associated with the training result.
    /// </summary>
    [Required]
    public TrainingPlan TrainingPlan { get; private set; }

    /// <summary>
    /// The collection of exercise scores associated with the training result.
    /// </summary>
    public ISet<ExerciseScore> ExercisesScores { get; private set; } = new HashSet<ExerciseScore>();

    private TrainingResult() { }

    public TrainingResult(User? user, TrainingPlan? trainingPlan)
    {
        SetUser(user);
        SetTrainingPlan(trainingPlan);
    }

    public TrainingResult(User? user, TrainingPlan? trainingPlan, ICollection<ExerciseScore> exercisesScores) : this(user, trainingPlan)
    {
        Update(exercisesScores);
    }

    public void Update(ICollection<ExerciseScore> exercisesScores)
    {
        SetExercises(exercisesScores);
    }

    public void SetUser(User? user)
        => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetTrainingPlan(TrainingPlan? trainingPlan)
        => TrainingPlan = trainingPlan ?? throw new ArgumentNullException(nameof(trainingPlan));

    public void SetExercises(ICollection<ExerciseScore> exercisesScores)
        => ExercisesScores = (exercisesScores is not null && exercisesScores.Any()) 
        ? new HashSet<ExerciseScore>(exercisesScores)
        : throw new ArgumentNullException(nameof(exercisesScores));
}