namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a user is over the maximum age limit for a kart.
/// </summary>
/// <param name="userAge">The user's age.</param>
/// <param name="maxAllowedAge">The maximum allowed age.</param>
public class UserOverAgeException(int userAge, int maxAllowedAge)
    : InvalidOperationException($"User is {userAge} years old, but the maximum allowed age is {maxAllowedAge}.")
{
    public int UserAge => userAge;
    public int MaxAllowedAge => maxAllowedAge;
}