namespace CbChallenge.Core;

/// <summary>
/// Interface for importers that transform arbitrary data into data models.
public interface IImporter
{
    public void MapObjects();
}