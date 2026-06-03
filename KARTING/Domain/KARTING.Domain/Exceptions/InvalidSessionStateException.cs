using KARTING.Domain.Enums;  // ← добавить эту строку

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a session operation is invalid for its current state.
/// </summary>
public class InvalidSessionStateException(SessionStatus currentState, SessionStatus targetState)
    : InvalidOperationException($"Cannot transition session from {currentState} to {targetState}.")
{
    public SessionStatus CurrentState => currentState;
    public SessionStatus TargetState => targetState;
}