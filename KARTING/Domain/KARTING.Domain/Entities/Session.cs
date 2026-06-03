using KARTING.Domain.Base;
using KARTING.Domain.Exceptions;
using KARTING.Domain.Enums;
using Domain.ValueObjects;

namespace KARTING.Domain.Entities;

/// <summary>
/// Represents a racing session in the karting system.
/// </summary>
public class Session(Guid id, DateTime startTime, Kart kart) : Entity<Guid>(id)
{
    /// <summary>
    /// Gets the session start time.
    /// </summary>
    public DateTime StartTime { get; private set; } = startTime;

    /// <summary>
    /// Gets the kart used in this session.
    /// </summary>
    public Kart Kart { get; private set; } = kart ?? throw new ArgumentNullValueException(nameof(kart));

    /// <summary>
    /// Gets the session status.
    /// </summary>
    public SessionStatus Status { get; private set; } = SessionStatus.Scheduled;

    /// <summary>
    /// Bookings for this session.
    /// </summary>
    private readonly ICollection<Booking> _bookings = [];

    /// <summary>
    /// Gets the session's bookings.
    /// </summary>
    public IReadOnlyCollection<Booking> Bookings =>
        _bookings.ToList().AsReadOnly();

    /// <summary>
    /// Gets the maximum capacity (can be configured).
    /// </summary>
    public const int MaxCapacity = 10;

    /// <summary>
    /// Gets the current number of participants.
    /// </summary>
    public int CurrentParticipants => _bookings.Count(b => b.Status == BookingStatus.Confirmed);

    /// <summary>
    /// Checks if the session is full.
    /// </summary>
    public bool IsFull => CurrentParticipants >= MaxCapacity;

    /// <summary>
    /// Adds a booking to the session.
    /// </summary>
    internal void AddBooking(Booking booking)
    {
        if (booking == null) throw new ArgumentNullValueException(nameof(booking));
        if (!_bookings.Contains(booking))
            _bookings.Add(booking);
    }

    /// <summary>
    /// Starts the session.
    /// </summary>
    public void Start()
    {
        if (Status != SessionStatus.Scheduled)
            throw new InvalidSessionStateException(Status, SessionStatus.InProgress);
        
        if (!Kart.IsAvailable)
            throw new KartNotAvailableException(Kart);
        
        Status = SessionStatus.InProgress;
    }

    /// <summary>
    /// Completes the session.
    /// </summary>
    public void Complete()
    {
        if (Status != SessionStatus.InProgress)
            throw new InvalidSessionStateException(Status, SessionStatus.Completed);
        
        Status = SessionStatus.Completed;
    }

    /// <summary>
    /// Cancels the session.
    /// </summary>
    public void Cancel()
    {
        if (Status == SessionStatus.Completed)
            throw new InvalidSessionStateException(Status, SessionStatus.Cancelled);
        
        Status = SessionStatus.Cancelled;
    }
}