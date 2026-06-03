using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents a kart's type (e.g., "Sprint", "Off-road", "Electric").
/// </summary>
/// <param name="type">The type of the kart.</param>
public class KartType(string type) : ValueObject<string>(new KartTypeValidator(), type);