using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents a participant's age.
/// </summary>
/// <param name="age">The age of the participant.</param>
public class Age(int age) : ValueObject<int>(new AgeValidator(), age);