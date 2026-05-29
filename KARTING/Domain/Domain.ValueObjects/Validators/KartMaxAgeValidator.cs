using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators;

/// <summary>
/// Валидатор для максимального возраста карта (таблица karts, поле max_age).
/// </summary>
public class KartMaxAgeValidator : IValidator<int>
{
    public static int MIN => 0;    // 0 = нет ограничения
    public static int MAX => 99;

    public void Validate(int value)
    {
        if (value < MIN)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN, MAX);

        if (value > MAX)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN, MAX);
    }
}