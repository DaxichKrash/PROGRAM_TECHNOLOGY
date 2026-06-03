using KARTING.Domain.Base;
using KARTING.Domain.Exceptions;
using KARTING.Domain.Enums;
using Domain.ValueObjects;

namespace KARTING.Domain.Entities;

/// <summary>
/// Represents a booking in the karting system.
/// </summary>
public class Booking : Entity<Guid>
{
    /// <summary>
    /// Gets the user who made the booking.
    /// </summary>
    public User User { get; private set; } = default!;

    /// <summary>
    /// Gets the session that was booked.
    /// </summary>
    public Session Session { get; private set; } = default!;

    /// <summary>
    /// Gets the participant's age at the time of booking.
    /// </summary>
    public Age ParticipantAge { get; private set; } = default!;

    /// <summary>
    /// Gets the booking status.
    /// </summary>
    public BookingStatus Status { get; private set; } = BookingStatus.Pending;

    /// <summary>
    /// Protected constructor for Entity Framework.
    /// </summary>
    protected Booking()
    {
    }

    /// <summary>
    /// Initializes a new booking.
    /// </summary>
    public Booking(User user, Session session, Age participantAge)
        : this(Guid.NewGuid(), user, session, participantAge, BookingStatus.Pending)
    {
    }

    /// <summary>
    /// Protected constructor for inheritance.
    /// </summary>
    protected Booking(Guid id, User user, Session session, Age participantAge, BookingStatus status)
        : base(id)
    {
        User = user ?? throw new ArgumentNullValueException(nameof(user));
        Session = session ?? throw new ArgumentNullValueException(nameof(session));
        ParticipantAge = participantAge ?? throw new ArgumentNullValueException(nameof(participantAge));
        Status = status;

        ValidateAgeRequirement();
    }

    /// <summary>
    /// Validates that the participant meets the kart's age requirements.
    /// </summary>
    private void ValidateAgeRequirement()
    {
        var minAge = Session.Kart.MinAge.Value;
        if (ParticipantAge.Value < minAge)
            throw new UserUnderageException(ParticipantAge.Value, minAge);

        var maxAge = Session.Kart.MaxAge?.Value;
        if (maxAge.HasValue && ParticipantAge.Value > maxAge.Value)
            throw new UserOverAgeException(ParticipantAge.Value, maxAge.Value);
    }

    /// <summary>
    /// Confirms the booking.
    /// </summary>
    public void Confirm()
    {
        if (Status != BookingStatus.Pending)
            throw new InvalidBookingStateException(Status, BookingStatus.Confirmed);

        if (Session.IsFull)
            throw new SessionFullException(Session);

        if (!Session.Kart.IsAvailable)
            throw new KartNotAvailableException(Session.Kart);

        Status = BookingStatus.Confirmed;
    }

    /// <summary>
    /// Cancels the booking.
    /// </summary>
    public void Cancel()
    {
        if (Status == BookingStatus.Completed || Status == BookingStatus.Cancelled)
            throw new InvalidBookingStateException(Status, BookingStatus.Cancelled);

        Status = BookingStatus.Cancelled;
    }

    /// <summary>
    /// Completes the booking (after session is done).
    /// </summary>
    public void Complete()
    {
        if (Status != BookingStatus.Confirmed)
            throw new InvalidBookingStateException(Status, BookingStatus.Completed);

        Status = BookingStatus.Completed;
    }
}