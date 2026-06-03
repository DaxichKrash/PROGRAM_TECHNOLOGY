using KARTING.Domain.Base;
using KARTING.Domain.Exceptions;
using Domain.ValueObjects;  // ← здесь есть UserName

namespace KARTING.Domain.Entities;

/// <summary>
/// Represents an admin in the karting system.
/// </summary>
public class Admin(Guid id, UserName name) : Entity<Guid>(id)  // ← UserName вместо AdminName
{
    /// <summary>
    /// Gets the admin's name.
    /// </summary>
    public UserName Name { get; private set; } = name ?? throw new ArgumentNullValueException(nameof(name));

    /// <summary>
    /// Changes the admin's name.
    /// </summary>
    public bool ChangeName(UserName newName)  // ← UserName вместо AdminName
    {
        if (newName == null) throw new ArgumentNullValueException(nameof(newName));

        if (Name == newName) return false;

        Name = newName;
        return true;
    }
}