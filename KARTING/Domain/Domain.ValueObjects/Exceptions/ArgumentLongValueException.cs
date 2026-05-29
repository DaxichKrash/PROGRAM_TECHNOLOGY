namespace Domain.ValueObjects.Exceptions;

/// <summary>
/// Выбрасывается, когда значение превышает максимально допустимую длину/размер.
/// </summary>
public class ArgumentLongValueException(string paramName, object? actualValue, int maxLength)
    : ArgumentException($"Argument \"{paramName}\" with value \"{actualValue}\" exceeds maximum length of {maxLength}.", paramName)
{
}
