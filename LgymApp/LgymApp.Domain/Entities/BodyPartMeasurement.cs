﻿using LgymApp.Domain.Common;
using LgymApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LgymApp.Domain.Entities;

/// <summary>
/// Measurement of body part
/// </summary>
public class BodyPartMeasurement : BaseEntity<BodyPartMeasurement>
{
    public new const string TableName = "body_part_measurements";
    
    /// <summary>
    /// The user associated with the body part measurement.
    /// </summary>
    public User User { get; private set; }

    /// <summary>
    /// The unique identifier of the user associated with the body part measurement.
    /// </summary>
    public Guid UserId { get; private set; }

    /// <summary>
    /// The body part being measured.
    /// </summary>
    public BodyPartsEnum BodyPart { get; private set; }

    /// <summary>
    /// The weight unit of the measurement.
    /// </summary>
    public WeightDataUnitsEnum WeightUnit { get; private set; }

    /// <summary>
    /// The weight value of the measurement.
    /// </summary>
    public double Weight { get; private set; }

    private BodyPartMeasurement() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BodyPartMeasurement"/> class.
    /// </summary>
    /// <param name="user">The user associated with the body part measurement.</param>
    /// <param name="bodyPart">The body part being measured.</param>
    /// <param name="weightUnit">The weight unit of the measurement.</param>
    /// <param name="weight">The weight value of the measurement.</param>
    public BodyPartMeasurement(User user, BodyPartsEnum bodyPart, WeightDataUnitsEnum weightUnit, double weight)
    {
        SetUser(user);
        Update(bodyPart, weightUnit, weight);
    }

    /// <summary>
    /// Updates the body part measurement with new values.
    /// </summary>
    /// <param name="bodyPart">The body part being measured.</param>
    /// <param name="weightUnit">The weight unit of the measurement.</param>
    /// <param name="weight">The weight value of the measurement.</param>
    public void Update(BodyPartsEnum bodyPart, WeightDataUnitsEnum weightUnit, double weight)
    {
        SetBodyPart(bodyPart);
        SetWeightUnit(weightUnit);
        SetWeight(weight);
    }

    /// <summary>
    /// Sets the user associated with the body part measurement.
    /// </summary>
    /// <param name="user">The user to set.</param>
    public void SetUser(User? user)
        => User = user ?? throw new ArgumentNullException(nameof(user));

    /// <summary>
    /// Sets the body part being measured.
    /// </summary>
    /// <param name="bodyPart">The body part to set.</param>
    public void SetBodyPart(BodyPartsEnum bodyPart)
        => BodyPart = bodyPart;

    /// <summary>
    /// Sets the weight unit of the measurement.
    /// </summary>
    /// <param name="weightUnit">The weight unit to set.</param>
    public void SetWeightUnit(WeightDataUnitsEnum weightUnit)
        => WeightUnit = weightUnit;

    /// <summary>
    /// Sets the weight value of the measurement.
    /// </summary>
    /// <param name="weight">The weight value to set.</param>
    public void SetWeight(double weight)
        => Weight = weight >= 0
        ? weight : throw new ArgumentOutOfRangeException(nameof(weight));
}
