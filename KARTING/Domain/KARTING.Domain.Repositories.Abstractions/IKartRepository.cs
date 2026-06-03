using KARTING.Domain.Entities;
using KARTING.Domain.Repositories.Abstractions.Base;
using KARTING.Domain.Enums;
using Domain.ValueObjects;

namespace KARTING.Domain.Repositories.Abstractions;

/// <summary>
/// Репозиторий для работы с картами
/// </summary>
public interface IKartRepository : IRepository<Kart, Guid>
{
    /// <summary>
    /// Получить все доступные карты
    /// </summary>
    Task<IReadOnlyList<Kart>> GetAvailableKartsAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить карты по статусу
    /// </summary>
    Task<IReadOnlyList<Kart>> GetByStatusAsync(KartStatus status, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить карты, подходящие по возрасту
    /// </summary>
    Task<IReadOnlyList<Kart>> GetKartsSuitableForAgeAsync(int age, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить карты по типу
    /// </summary>
    Task<IReadOnlyList<Kart>> GetByTypeAsync(KartType type, CancellationToken cancellationToken = default);
}