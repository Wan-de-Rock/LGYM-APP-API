using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LgymApp.Domain.Entities;

public class ExerciseScore : BaseEntity
{
    [Required, ForeignKey(nameof(LgymApp.Domain.Entities.Exercise))]
    public Exercise Exercise { get; private set; }

    [Required, ForeignKey(nameof(Entities.User))]
    public User User { get; private set; }

    [Required, ForeignKey(nameof(Entities.Training))]
    public Training Training { get; private set; }

    [Required]
    public int Repeats { get; private set; }

    [Required]
    public int Series { get; private set; }

    [Required]
    public double Weight { get; private set; }

    [Required]
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    public ExerciseScore(Exercise? exercise, User? user, Training? training, int repeats, int series, double weight, WeightDataUnitsEnum weightUnit)
    {
        SetExercise(exercise);
        SetUser(user);
        SetTraining(training);

        Update(repeats, series, weight, weightUnit);
    }

    public void Update(int repeats, int series, double weight, WeightDataUnitsEnum weightUnit)
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

    public void SetTraining(Training? training) 
        => Training = training ?? throw new ArgumentNullException(nameof(training));

    public void SetRepeats(int repeats) 
        => Repeats = repeats >= 0 ? repeats : throw new ArgumentOutOfRangeException(nameof(repeats));

    public void SetSeries(int series)
        => Series = series > 0 ? series : throw new ArgumentOutOfRangeException(nameof(series));

    public void SetWeight(double weight)
        => Weight = weight >= 0 ? weight : throw new ArgumentOutOfRangeException(nameof(weight));

    public void SetWeightUnit(WeightDataUnitsEnum weightUnit) => WeightUnit = weightUnit;
}
