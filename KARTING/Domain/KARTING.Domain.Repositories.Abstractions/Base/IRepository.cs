using KARTING.Domain.Base;

namespace KARTING.Domain.Repositories.Abstractions.Base;

/// <summary>
/// Базовый репозиторий для всех сущностей
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TId">Тип идентификатора</typeparam>
public interface IRepository<TEntity, TId> 
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить все сущности
    /// </summary>
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Обновить существующую сущность
    /// </summary>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверить существование сущности
    /// </summary>
    Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);
}