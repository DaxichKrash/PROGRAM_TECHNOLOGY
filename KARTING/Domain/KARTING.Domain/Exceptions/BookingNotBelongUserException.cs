using KARTING.Domain.Entities;

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a booking does not belong to the specified user.
/// </summary>
/// <param name="booking">The booking that does not belong to the user.</param>
/// <param name="user">The user who does not own the booking.</param>
public class BookingNotBelongUserException(Booking booking, User user)
    : InvalidOperationException($"The booking (id = {booking.Id}) is not in the user's booking sequence (user {user.Name}).")
{
    public Booking Booking => booking;
    public User User => user;
}