using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators;

/// <summary>
/// Валидатор для типа карта (таблица karts, поле type).
/// </summary>
public class KartTypeValidator : IValidator<string>
{
    public static int MAX_LENGTH => 20;  // VARCHAR(20)
    public static int MIN_LENGTH => 2;   // "A", "B" — слишком коротко

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);

        if (value.Length < MIN_LENGTH)
            throw new ArgumentShortValueException(nameof(value), value, MIN_LENGTH);
    }
}