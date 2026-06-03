namespace Domain.ValueObjects.Exceptions;

/// <summary>
/// Выбрасывается, когда числовое значение выходит за допустимые пределы (min/max).
/// </summary>
public class ArgumentOutOfRangeValueException(string paramName, object? actualValue, int min, int max)
    : ArgumentOutOfRangeException(paramName, actualValue, $"Value must be between {min} and {max}. Actual: {actualValue}")
{
}
