using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Container for the training plan days.
/// </summary>
public class Plan : AuditableEntity
{
    /// <summary>
    /// The name of the plan.
    /// </summary>
    [Required, StringLength(50)]
    public string Name { get; private set; }

    /// <summary>
    /// The user associated with the plan.
    /// </summary>
    [Required]
    public User User { get; private set; }

    /// <summary>
    /// The set of plan days.
    /// </summary>
    public ISet<TrainingPlan> TrainingsDaysPlans { get; private set; } = new HashSet<TrainingPlan>();

    /// <summary>
    /// The number of training days in the plan.
    /// </summary>
    [Required]
    public int NumberOfTrainingDays { get; private set; } // TODO: remove

    private Plan() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Plan"/> class.
    /// </summary>
    /// <param name="name">The name of the plan.</param>
    /// <param name="numberOfTrainingDays">The number of training days in the plan.</param>
    /// <param name="user">The user associated with the plan.</param>
    /// <param name="trainingsDaysPlans">The set of plan days.</param>
    public Plan(string name, int numberOfTrainingDays, User user, ICollection<TrainingPlan> trainingsDaysPlans)
    {
        SetUser(user);
        Update(name, numberOfTrainingDays, trainingsDaysPlans);
    }

    /// <summary>
    /// Updates the plan with the specified details.
    /// </summary>
    /// <param name="name">The name of the plan.</param>
    /// <param name="numberOfTrainingDays">The number of training days in the plan.</param>
    /// <param name="trainingsDaysPlans">The set of plan days.</param>
    public void Update(string name, int numberOfTrainingDays, ICollection<TrainingPlan> trainingsDaysPlans)
    {
        SetName(name);
        SetNumberOfTrainingDays(numberOfTrainingDays);
        SetTrainingsDaysPlans(trainingsDaysPlans);
    }

    /// <summary>
    /// Sets the name of the plan.
    /// </summary>
    /// <param name="name">The name of the plan.</param>
    public void SetName(string name)
        => Name = !string.IsNullOrEmpty(name)
        ? name : throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// Sets the user associated with the plan.
    /// </summary>
    /// <param name="user">The user associated with the plan.</param>
    public void SetUser(User? user)
    => User = user ?? throw new ArgumentNullException(nameof(user));

    /// <summary>
    /// Sets the set of plan days.
    /// </summary>
    /// <param name="trainingsDaysPlans">The set of plan days.</param>
    public void SetTrainingsDaysPlans(ICollection<TrainingPlan> trainingsDaysPlans)
        => TrainingsDaysPlans = (trainingsDaysPlans is not null)
        ? new HashSet<TrainingPlan>(trainingsDaysPlans)
        : throw new ArgumentNullException(nameof(trainingsDaysPlans));

    /// <summary>
    /// Sets the number of training days in the plan.
    /// </summary>
    /// <param name="numberOfTrainingDays">The number of training days in the plan.</param>
    public void SetNumberOfTrainingDays(int numberOfTrainingDays)
        => NumberOfTrainingDays = numberOfTrainingDays > 0
        ? numberOfTrainingDays
        : throw new ArgumentOutOfRangeException(nameof(numberOfTrainingDays));
}
