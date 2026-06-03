using Domain.ValueObjects.Base;
using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects.Validators;

/// <summary>
/// Валидатор для возраста участника (таблица bookings, поле participant_age).
/// </summary>
public class AgeValidator : IValidator<int>
{
    public static int MIN_AGE => 6;    // Минимальный возраст для картинга
    public static int MAX_AGE => 99;   // Разумный максимум

    public void Validate(int value)
    {
        // Для int проверка на отрицательные числа
        if (value < MIN_AGE)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN_AGE, MAX_AGE);

        if (value > MAX_AGE)
            throw new ArgumentOutOfRangeValueException(nameof(value), value, MIN_AGE, MAX_AGE);
    }
}