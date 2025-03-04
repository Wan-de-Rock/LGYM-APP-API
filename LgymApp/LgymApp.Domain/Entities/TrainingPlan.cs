using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents a plan for a training day entity
/// </summary>
public class TrainingPlan : BaseEntity<TrainingPlan>
{
    public new const string TableName = "training_plans";
    
    /// <summary>
    /// The name of the plan day.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The plan associated with the plan day.
    /// </summary>
    public Plan Plan { get; private set; }

    public Guid PlanId { get; private set; }

    /// <summary>
    /// The recommended number of reps for the plan day.
    /// </summary>
    public ISet<RecommendedNumberOfReps> RecommendedNumberOfReps { get; private set; }
        = new HashSet<RecommendedNumberOfReps>();

    private TrainingPlan() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TrainingPlan"/> class.
    /// </summary>
    /// <param name="name">The name of the plan day.</param>
    /// <param name="plan">The plan associated with the plan day.</param>
    /// <param name="recommendedNumberOfReps">The recommended number of reps for the plan day.</param>
    public TrainingPlan(string name, Plan? plan, ICollection<RecommendedNumberOfReps> recommendedNumberOfReps)
    {
        Update(name, plan, recommendedNumberOfReps);
    }

    /// <summary>
    /// Updates the plan day with the specified details.
    /// </summary>
    /// <param name="name">The name of the plan day.</param>
    /// <param name="plan">The plan associated with the plan day.</param>
    /// <param name="recommendedNumberOfReps">The recommended number of reps for the plan day.</param>
    public void Update(string name, Plan? plan, ICollection<RecommendedNumberOfReps> recommendedNumberOfReps)
    {
        SetName(name);
        SetPlan(plan);
        SetRecommendedNumberOfReps(recommendedNumberOfReps);
    }

    /// <summary>
    /// Sets the name of the plan day.
    /// </summary>
    /// <param name="name">The name of the plan day.</param>
    public void SetName(string name)
        => Name = !string.IsNullOrEmpty(name)
        ? name : throw new ArgumentNullException(nameof(name));

    /// <summary>
    /// Sets the plan associated with the plan day.
    /// </summary>
    /// <param name="plan">The plan associated with the plan day.</param>
    public void SetPlan(Plan? plan)
        => Plan = plan ?? throw new ArgumentNullException(nameof(plan));

    /// <summary>
    /// Sets the recommended number of reps for the plan day.
    /// </summary>
    /// <param name="recommendedNumberOfReps">The recommended number of reps for the plan day.</param>
    public void SetRecommendedNumberOfReps(ICollection<RecommendedNumberOfReps> recommendedNumberOfReps)
        => RecommendedNumberOfReps = (recommendedNumberOfReps is not null && recommendedNumberOfReps.Any())
        ? new HashSet<RecommendedNumberOfReps>(recommendedNumberOfReps)
        : throw new ArgumentNullException(nameof(recommendedNumberOfReps));
}
