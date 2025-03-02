using LgymApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Represents the recommended number of repetitions for an exercise.
/// </summary>
public class RecommendedNumberOfReps : BaseEntity
{
    /// <summary>
    /// Gets the number of series.
    /// </summary>
    [Required]
    public int Series { get; private set; }

    /// <summary>
    /// Gets the number of repeats.
    /// </summary>
    [Required, StringLength(50)]
    public string Repeats { get; private set; } // TODO: change to min, max integers

    /// <summary>
    /// Gets the associated exercise.
    /// </summary>
    [Required]
    public Exercise Exercise { get; private set; }

    private RecommendedNumberOfReps() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="RecommendedNumberOfReps"/> class.
    /// </summary>
    /// <param name="series">The number of series.</param>
    /// <param name="repeats">The number of repeats.</param>
    /// <param name="exercise">The associated exercise.</param>
    public RecommendedNumberOfReps(int series, string repeats, Exercise? exercise)
    {
        SetExercise(exercise);
        Update(series, repeats);
    }

    /// <summary>
    /// Updates the series and repeats.
    /// </summary>
    /// <param name="series">The number of series.</param>
    /// <param name="repeats">The number of repeats.</param>
    public void Update(int series, string repeats)
    {
        SetSeries(series);
        SetRepeats(repeats);
    }

    /// <summary>
    /// Sets the number of series.
    /// </summary>
    /// <param name="series">The number of series.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the series is less than or equal to zero.</exception>
    public void SetSeries(int series)
        => Series = series > 0 ? series
        : throw new ArgumentOutOfRangeException(nameof(series));

    /// <summary>
    /// Sets the number of repeats.
    /// </summary>
    /// <param name="repeats">The number of repeats.</param>
    /// <exception cref="ArgumentNullException">Thrown when the repeats is null or empty.</exception>
    public void SetRepeats(string repeats)
        => Repeats = !string.IsNullOrEmpty(repeats)
        ? repeats : throw new ArgumentNullException(nameof(repeats));

    /// <summary>
    /// Sets the associated exercise.
    /// </summary>
    /// <param name="exercise">The associated exercise.</param>
    /// <exception cref="ArgumentNullException">Thrown when the exercise is null.</exception>
    public void SetExercise(Exercise? exercise)
        => Exercise = exercise ?? throw new ArgumentNullException(nameof(exercise));
}
