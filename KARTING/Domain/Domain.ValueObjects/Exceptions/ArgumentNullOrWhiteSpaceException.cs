namespace Domain.ValueObjects.Exceptions;

/// <summary>
/// Выбрасывается, когда строковый аргумент равен null, пуст или состоит из пробелов.
/// </summary>
public class ArgumentNullOrWhiteSpaceException(string paramName)
    : ArgumentException($"String argument \"{paramName}\" cannot be null, empty or whitespace.", paramName)
{
}