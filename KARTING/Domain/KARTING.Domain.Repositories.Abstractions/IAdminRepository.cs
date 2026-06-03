using KARTING.Domain.Entities;
using KARTING.Domain.Repositories.Abstractions.Base;
using Domain.ValueObjects;

namespace KARTING.Domain.Repositories.Abstractions;

/// <summary>
/// Репозиторий для работы с администраторами
/// </summary>
public interface IAdminRepository : IRepository<Admin, Guid>
{
    /// <summary>
    /// Получить администратора по имени
    /// </summary>
    Task<Admin?> GetByNameAsync(UserName name, CancellationToken cancellationToken = default);
}