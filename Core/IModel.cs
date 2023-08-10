namespace CbChallenge.Core;

/// <summary>
/// Interface for data models.
/// </summary>
public interface IModel
{
    /// <summary>
    /// A string that uniquely identifies a <see cref="IModel" /> instance among other IModels of the same type.
    /// <summary>
    public string Id { get; }
}