using KARTING.Domain.Base;
using KARTING.Domain.Exceptions;
using Domain.ValueObjects;

namespace KARTING.Domain.Entities;

/// <summary>
/// Represents a user in the karting system.
/// </summary>
public class User(Guid id, UserName name, DateOnly birthDate) : Entity<Guid>(id)
{
    /// <summary>
    /// User's bookings.
    /// </summary>
    private readonly ICollection<Booking> _bookings = [];

    /// <summary>
    /// Gets the user's name.
    /// </summary>
    public UserName Name { get; private set; } = name ?? throw new ArgumentNullValueException(nameof(name));

    /// <summary>
    /// Gets the user's birth date.
    /// </summary>
    public DateOnly BirthDate { get; private set; } = birthDate;

    /// <summary>
    /// Gets the user's age (calculated from birth date).
    /// </summary>
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }
    }

    /// <summary>
    /// Gets the user's bookings.
    /// </summary>
    public IReadOnlyCollection<Booking> Bookings =>
        _bookings.ToList().AsReadOnly();

    /// <summary>
    /// Changes the user's name.
    /// </summary>
    public bool ChangeName(UserName newName)
    {
        if (newName == null) throw new ArgumentNullValueException(nameof(newName));

        if (Name == newName) return false;

        Name = newName;
        return true;
    }

    /// <summary>
    /// Creates a new booking for the user.
    /// </summary>
    public Booking CreateBooking(Session session, Age participantAge)
    {
        if (session == null) throw new ArgumentNullValueException(nameof(session));
        
        var booking = new Booking(this, session, participantAge);
        _bookings.Add(booking);
        session.AddBooking(booking);
        return booking;
    }

    /// <summary>
    /// Cancels a booking.
    /// </summary>
    public void CancelBooking(Booking booking)
    {
        if (booking.User != this) throw new AnotherUserCancelBookingException(booking, this);

        if (!_bookings.Contains(booking)) throw new BookingNotBelongUserException(booking, this);

        booking.Cancel();
    }
}