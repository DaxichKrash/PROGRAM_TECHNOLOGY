using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents the minimum age requirement for a kart.
/// </summary>
/// <param name="minAge">The minimum age allowed to drive this kart.</param>
public class KartMinAge(int minAge) : ValueObject<int>(new KartMinAgeValidator(), minAge);