using KARTING.Domain.Base;
using KARTING.Domain.Exceptions;
using KARTING.Domain.Enums;
using Domain.ValueObjects;

namespace KARTING.Domain.Entities;

/// <summary>
/// Represents a kart in the karting system.
/// </summary>
public class Kart(Guid id, KartName name, KartType type, KartMinAge minAge, KartMaxAge? maxAge) : Entity<Guid>(id)
{
    /// <summary>
    /// Gets the kart's name.
    /// </summary>
    public KartName Name { get; private set; } = name ?? throw new ArgumentNullValueException(nameof(name));

    /// <summary>
    /// Gets the kart's type.
    /// </summary>
    public KartType Type { get; private set; } = type ?? throw new ArgumentNullValueException(nameof(type));

    /// <summary>
    /// Gets the minimum age required to drive this kart.
    /// </summary>
    public KartMinAge MinAge { get; private set; } = minAge ?? throw new ArgumentNullValueException(nameof(minAge));

    /// <summary>
    /// Gets the maximum age allowed to drive this kart (null = no limit).
    /// </summary>
    public KartMaxAge? MaxAge { get; private set; } = maxAge;

    /// <summary>
    /// Gets the kart's status.
    /// </summary>
    public KartStatus Status { get; private set; } = KartStatus.Available;

    /// <summary>
    /// Sessions associated with this kart.
    /// </summary>
    private readonly ICollection<Session> _sessions = [];

    /// <summary>
    /// Gets the kart's sessions.
    /// </summary>
    public IReadOnlyCollection<Session> Sessions =>
        _sessions.ToList().AsReadOnly();

    /// <summary>
    /// Changes the kart's name.
    /// </summary>
    public bool ChangeName(KartName newName)
    {
        if (newName == null) throw new ArgumentNullValueException(nameof(newName));
        if (Name == newName) return false;
        Name = newName;
        return true;
    }

    /// <summary>
    /// Changes the kart's type.
    /// </summary>
    public bool ChangeType(KartType newType)
    {
        if (newType == null) throw new ArgumentNullValueException(nameof(newType));
        if (Type == newType) return false;
        Type = newType;
        return true;
    }

    /// <summary>
    /// Sets the kart's status to maintenance.
    /// </summary>
    public void SetMaintenance()
    {
        Status = KartStatus.Maintenance;
    }

    /// <summary>
    /// Sets the kart's status to broken.
    /// </summary>
    public void SetBroken()
    {
        Status = KartStatus.Broken;
    }

    /// <summary>
    /// Sets the kart's status to available.
    /// </summary>
    public void SetAvailable()
    {
        Status = KartStatus.Available;
    }

    /// <summary>
    /// Checks if the kart is available for booking.
    /// </summary>
    public bool IsAvailable => Status == KartStatus.Available;

    /// <summary>
    /// Adds a session to the kart.
    /// </summary>
    internal void AddSession(Session session)
    {
        if (session == null) throw new ArgumentNullValueException(nameof(session));
        if (!_sessions.Contains(session))
            _sessions.Add(session);
    }
}