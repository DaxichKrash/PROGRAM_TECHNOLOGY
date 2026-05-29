using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents a kart's name.
/// </summary>
/// <param name="name">The name of the kart.</param>
public class KartName(string name) : ValueObject<string>(new KartNameValidator(), name);