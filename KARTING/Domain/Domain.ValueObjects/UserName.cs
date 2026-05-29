using Domain.ValueObjects.Base;
using Domain.ValueObjects.Validators;

namespace Domain.ValueObjects;

/// <summary>
/// Represents a user's name.
/// </summary>
/// <param name="name">The name of the user.</param>
public class UserName(string name) : ValueObject<string>(new UserNameValidator(), name);