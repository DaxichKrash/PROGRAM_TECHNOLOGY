namespace KARTING.Domain.Exceptions;

/// <summary>
/// Thrown when modification data is invalid (e.g., before creation date).
/// </summary>
/// <param name="entityType">The type of entity being modified.</param>
/// <param name="modificationData">The invalid modification date.</param>
public class InvalidModificationDataException(string entityType, DateTime modificationData)
    : ArgumentException($"The modification time {modificationData} for {entityType} is not correct.")
{
    public string EntityType => entityType;
    public DateTime ModificationData => modificationData;
}