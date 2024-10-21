using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class Training : BaseEntity
{
    [Required, ForeignKey(nameof(Entities.User))]
    public User User { get; private set; }

    [Required, ForeignKey(nameof(Entities.PlanDay))]
    public PlanDay PlanDay { get; private set; }

    public ISet<Exercise> Exercises { get; private set; } = new HashSet<Exercise>();

    public Training(User? user, PlanDay? planDay)
    {
        SetUser(user);
        SetPlanDay(planDay);
    }

    public Training(User? user, PlanDay? planDay, ICollection<Exercise> exercises) : this(user, planDay)
    {
        SetExercises(exercises);
    }

    public void SetUser(User? user)
        => User = user ?? throw new ArgumentNullException(nameof(user));

    public void SetPlanDay(PlanDay? planDay)
        => PlanDay = planDay ?? throw new ArgumentNullException(nameof(planDay));

    public void SetExercises(ICollection<Exercise> exercises)
        => Exercises = (exercises is not null && exercises.Any()) 
        ? new HashSet<Exercise>(exercises)
        : throw new ArgumentNullException(nameof(exercises));
}