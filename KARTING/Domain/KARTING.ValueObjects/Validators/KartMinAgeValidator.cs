using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators;

/// <summary>
/// Валидатор для минимального возраста карта (таблица karts, поле min_age).
/// </summary>
public class KartMinAgeValidator : IValidator<int>
{
    public static int MIN => 6;
    public static int MAX => 18;

    public void Validate(int value)
    {
        if (value < MIN)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN, MAX);

        if (value > MAX)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN, MAX);
    }
}