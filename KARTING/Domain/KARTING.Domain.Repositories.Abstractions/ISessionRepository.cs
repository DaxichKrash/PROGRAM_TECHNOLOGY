using KARTING.Domain.Entities;
using KARTING.Domain.Repositories.Abstractions.Base;
using KARTING.Domain.Enums;

namespace KARTING.Domain.Repositories.Abstractions;

/// <summary>
/// Репозиторий для работы с сессиями
/// </summary>
public interface ISessionRepository : IRepository<Session, Guid>
{
    /// <summary>
    /// Получить сессии за период
    /// </summary>
    Task<IReadOnlyList<Session>> GetSessionsInPeriodAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить сессии по статусу
    /// </summary>
    Task<IReadOnlyList<Session>> GetByStatusAsync(SessionStatus status, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить предстоящие сессии
    /// </summary>
    Task<IReadOnlyList<Session>> GetUpcomingSessionsAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить сессии для конкретного карта
    /// </summary>
    Task<IReadOnlyList<Session>> GetByKartIdAsync(Guid kartId, CancellationToken cancellationToken = default);
}