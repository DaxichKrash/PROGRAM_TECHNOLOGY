using KARTING.Domain.Entities;

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a user tries to cancel a booking that belongs to another user.
/// </summary>
/// <param name="booking">The booking that cannot be cancelled.</param>
/// <param name="user">The user who attempted to cancel the booking.</param>
public class AnotherUserCancelBookingException(Booking booking, User user)
    : InvalidOperationException($"The user {user.Name} can't cancel the booking (id = {booking.Id}) owned by the user {booking.User.Name}.")
{
    public Booking Booking => booking;
    public User User => user;
}