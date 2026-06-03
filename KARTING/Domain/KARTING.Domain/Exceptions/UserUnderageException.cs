namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a user is under the minimum age requirement for a kart.
/// </summary>
/// <param name="userAge">The user's age.</param>
/// <param name="minRequiredAge">The minimum required age.</param>
public class UserUnderageException(int userAge, int minRequiredAge)
    : InvalidOperationException($"User is {userAge} years old, but the minimum required age is {minRequiredAge}.")
{
    public int UserAge => userAge;
    public int MinRequiredAge => minRequiredAge;
}