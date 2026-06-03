namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when an argument is null.
/// </summary>
/// <param name="paramName">The name of the parameter that is null.</param>
public class ArgumentNullValueException(string paramName)
    : ArgumentNullException(paramName, $"Argument \"{paramName}\" value is null");