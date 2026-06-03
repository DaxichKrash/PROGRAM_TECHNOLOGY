using KARTING.Domain.Entities;

namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when a kart is not available for booking.
/// </summary>
/// <param name="kart">The kart that is not available.</param>
public class KartNotAvailableException(Kart kart)
    : InvalidOperationException($"The kart '{kart.Name}' is not available (current status: {kart.Status}).")
{
    public Kart Kart => kart;
}