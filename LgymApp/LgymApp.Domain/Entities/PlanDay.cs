using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class PlanDay : BaseEntity
{
    [Required]
    public string Name { get; private set; }

    [Required, ForeignKey(nameof(Entities.Plan))]
    public Plan Plan { get; private set; }

    public PlanDay(string name, Plan? plan)
    {
        Update(name, plan);
    }

    public void Update(string name, Plan? plan)
    {
        SetName(name);
        SetPlan(plan);
    }

    public void SetName(string name)
        => Name = !string.IsNullOrEmpty(name)
        ? name : throw new ArgumentNullException(nameof(name));

    public void SetPlan(Plan? plan)
        => Plan = plan ?? throw new ArgumentNullException(nameof(plan));
}
