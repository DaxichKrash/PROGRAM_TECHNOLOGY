using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents the maximum age limit for a kart (0 means no limit).
/// </summary>
/// <param name="maxAge">The maximum age allowed to drive this kart.</param>
public class KartMaxAge(int maxAge) : ValueObject<int>(new KartMaxAgeValidator(), maxAge);