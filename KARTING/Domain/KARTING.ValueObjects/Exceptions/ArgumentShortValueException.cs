namespace Domain.ValueObjects.Exceptions;

/// <summary>
/// Выбрасывается, когда значение короче минимально допустимой длины.
/// </summary>
public class ArgumentShortValueException(string paramName, object? actualValue, int minLength)
    : ArgumentException($"Argument \"{paramName}\" with value \"{actualValue}\" is shorter than minimum length of {minLength}.", paramName)
{
}