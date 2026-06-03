namespace KARTING.Domain.Enums;

/// <summary>
/// Represents the status of a kart.
/// </summary>
public enum KartStatus
{
    Available,
    Maintenance,
    Broken
}

/// <summary>
/// Represents the status of a booking.
/// </summary>
public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}

/// <summary>
/// Represents the status of a session.
/// </summary>
public enum SessionStatus
{
    Scheduled,
    InProgress,
    Completed,
    Cancelled
}