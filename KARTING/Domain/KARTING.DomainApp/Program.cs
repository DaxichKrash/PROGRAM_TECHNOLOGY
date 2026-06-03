using KARTING.Domain.Entities;
using KARTING.Domain.Enums;
using Domain.ValueObjects;

Console.WriteLine("=== KARTING Domain Demo ===\n");

// 1. Демонстрация валидации UserName
Console.WriteLine("1. Создание пользователя:");
try
{
    var invalidName = new UserName("A"); // Слишком короткое имя
}
catch (Exception ex)
{
    Console.WriteLine($"   ❌ Ошибка (ожидаемо): {ex.Message}");
}

var userName = new UserName("Анна");
var user = new User(Guid.NewGuid(), userName, new DateOnly(2000, 5, 15));
Console.WriteLine($"   ✅ Создан пользователь: {user.Name}, возраст: {user.Age}\n");

// 2. Создание карта
Console.WriteLine("2. Создание карта:");
var kartName = new KartName("Болид-1");
var kartType = new KartType("Спортивный");
var minAge = new KartMinAge(12);
var maxAge = new KartMaxAge(99);

var kart = new Kart(Guid.NewGuid(), kartName, kartType, minAge, maxAge);
Console.WriteLine($"   ✅ Создан карт: {kart.Name}, тип: {kart.Type}, мин. возраст: {kart.MinAge.Value}\n");

// 3. Создание сессии
Console.WriteLine("3. Создание сессии:");
var session = new Session(Guid.NewGuid(), DateTime.Now.AddDays(1), kart);
Console.WriteLine($"   ✅ Создана сессия: {session.StartTime}, статус: {session.Status}\n");

// 4. Успешное бронирование
Console.WriteLine("4. Создание бронирования (возраст подходит):");
try
{
    var participantAge = new Age(25);
    var booking = user.CreateBooking(session, participantAge);
    
    Console.WriteLine($"   ✅ Создано бронирование:");
    Console.WriteLine($"      - Пользователь: {booking.User.Name}");
    Console.WriteLine($"      - Возраст участника: {booking.ParticipantAge.Value}");
    Console.WriteLine($"      - Статус: {booking.Status}");
    
    booking.Confirm();
    Console.WriteLine($"      - После подтверждения: {booking.Status}\n");
}
catch (Exception ex)
{
    Console.WriteLine($"   ❌ Ошибка: {ex.Message}\n");
}

// 5. Бронирование с неподходящим возрастом
Console.WriteLine("5. Создание бронирования (возраст НЕ подходит):");
try
{
    var youngUser = new User(Guid.NewGuid(), new UserName("Петя"), new DateOnly(2018, 1, 1));
    var youngAge = new Age(6); // 6 лет, а минимальный возраст карта - 12
    
    var invalidBooking = youngUser.CreateBooking(session, youngAge);
    invalidBooking.Confirm();
}
catch (Exception ex)
{
    Console.WriteLine($"   ❌ Ошибка (ожидаемо): {ex.Message}\n");
}

// 6. Демонстрация смены имени
Console.WriteLine("6. Смена имени пользователя:");
Console.WriteLine($"   Было: {user.Name}");
user.ChangeName(new UserName("Анна Иванова"));
Console.WriteLine($"   Стало: {user.Name}\n");

// 7. Демонстрация статусов карта
Console.WriteLine("7. Изменение статуса карта:");
Console.WriteLine($"   Статус: {kart.Status}");
kart.SetMaintenance();
Console.WriteLine($"   После обслуживания: {kart.Status}");
kart.SetAvailable();
Console.WriteLine($"   Снова доступен: {kart.Status}\n");

// 8. Демонстрация отмены бронирования
Console.WriteLine("8. Отмена бронирования:");
try
{
    var participantAge = new Age(30);
    var bookingToCancel = user.CreateBooking(session, participantAge);
    Console.WriteLine($"   Создано бронирование со статусом: {bookingToCancel.Status}");
    
    user.CancelBooking(bookingToCancel);
    Console.WriteLine($"   После отмены: {bookingToCancel.Status}\n");
}
catch (Exception ex)
{
    Console.WriteLine($"   ❌ Ошибка: {ex.Message}\n");
}

// 9. Демонстрация заполненной сессии
Console.WriteLine("9. Проверка лимита сессии (максимум 10 участников):");
for (int i = 0; i < 12; i++)
{
    var tempUser = new User(Guid.NewGuid(), new UserName($"Гонщик{i+1}"), new DateOnly(1990, 1, 1));
    var tempAge = new Age(20);
    
    try
    {
        var tempBooking = tempUser.CreateBooking(session, tempAge);
        tempBooking.Confirm();
        Console.WriteLine($"   Участник {i+1}: добавлен (всего подтверждённых: {session.CurrentParticipants})");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"   Участник {i+1}: ❌ {ex.Message}");
    }
}

Console.WriteLine("\n=== Демонстрация завершена ===");
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();