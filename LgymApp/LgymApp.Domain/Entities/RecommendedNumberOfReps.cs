using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class RecommendedNumberOfReps : BaseEntity
{
    [Required]
    public int Series { get; private set; }

    [Required]
    public string Repeats { get; private set; } // TODO: change to min, max integers

    [Required, ForeignKey(nameof(Entities.Exercise))]
    public Exercise Exercise { get; private set; }

    public RecommendedNumberOfReps(int series, string repeats, Exercise? exercise)
    {
        SetExercise(exercise);
        Update(series, repeats);
    }

    public void Update(int series, string repeats)
    {
        SetSeries(series);
        SetRepeats(repeats);
    }

    public void SetSeries(int series)
        => Series = series > 0 ? series 
        : throw new ArgumentOutOfRangeException(nameof(series));

    public void SetRepeats(string repeats)
        => Repeats = !string.IsNullOrEmpty(repeats)
        ? repeats : throw new ArgumentNullException(nameof(repeats));

    public void SetExercise(Exercise? exercise)
        => Exercise = exercise ?? throw new ArgumentNullException(nameof(exercise));

}