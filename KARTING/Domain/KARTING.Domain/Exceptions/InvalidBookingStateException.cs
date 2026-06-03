using KARTING.Domain.Enums;

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a booking operation is invalid for its current state.
/// </summary>
/// <param name="currentState">The current state of the booking.</param>
/// <param name="targetState">The target state that was attempted.</param>
public class InvalidBookingStateException(BookingStatus currentState, BookingStatus targetState)
    : InvalidOperationException($"Cannot transition booking from {currentState} to {targetState}.")
{
    public BookingStatus CurrentState => currentState;
    public BookingStatus TargetState => targetState;
}