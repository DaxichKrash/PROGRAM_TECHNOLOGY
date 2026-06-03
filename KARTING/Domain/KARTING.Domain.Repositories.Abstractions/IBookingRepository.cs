using KARTING.Domain.Entities;
using KARTING.Domain.Repositories.Abstractions.Base;
using KARTING.Domain.Enums;

namespace KARTING.Domain.Repositories.Abstractions;

/// <summary>
/// Репозиторий для работы с бронированиями
/// </summary>
public interface IBookingRepository : IRepository<Booking, Guid>
{
    /// <summary>
    /// Получить бронирования пользователя
    /// </summary>
    Task<IReadOnlyList<Booking>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить бронирования по статусу
    /// </summary>
    Task<IReadOnlyList<Booking>> GetByStatusAsync(BookingStatus status, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить активные бронирования пользователя
    /// </summary>
    Task<IReadOnlyList<Booking>> GetActiveBookingsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить бронирования для сессии
    /// </summary>
    Task<IReadOnlyList<Booking>> GetBySessionIdAsync(Guid sessionId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверить, есть ли у пользователя активные бронирования на это время
    /// </summary>
    Task<bool> HasConflictAsync(Guid userId, DateTime sessionStartTime, CancellationToken cancellationToken = default);
}