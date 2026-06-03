using KARTING.Domain.Entities;
using KARTING.Domain.Repositories.Abstractions.Base;
using Domain.ValueObjects;

namespace KARTING.Domain.Repositories.Abstractions;

/// <summary>
/// Репозиторий для работы с пользователями
/// </summary>
public interface IUserRepository : IRepository<User, Guid>
{
    /// <summary>
    /// Получить пользователя по имени
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<User?> GetByNameAsync(UserName name, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить пользователя с его бронированиями
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<User?> GetUserWithBookingsAsync(Guid userId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить пользователя по части имени (для поиска)
    /// </summary>
    Task<IReadOnlyList<User>> SearchByNameAsync(string searchTerm, CancellationToken cancellationToken = default);
}