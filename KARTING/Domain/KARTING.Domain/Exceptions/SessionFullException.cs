using KARTING.Domain.Entities;

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when trying to book a session that is already full.
/// </summary>
/// <param name="session">The session that is full.</param>
public class SessionFullException(Session session)
    : InvalidOperationException($"The session at {session.StartTime} is already full (max capacity: {Session.MaxCapacity}).")
{
    public Session Session => session;
}