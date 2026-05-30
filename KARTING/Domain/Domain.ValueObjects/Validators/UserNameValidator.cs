using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators;

/// <summary>
/// Валидатор для имени пользователя (таблица users, поле name).
/// </summary>
public class UserNameValidator : IValidator<string>
{
    public static int MAX_LENGTH => 50;  // VARCHAR(50)
    public static int MIN_LENGTH => 2;   // Минимальное имя — 2 символа

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
