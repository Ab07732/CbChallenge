using System.Text.Json.Nodes;

namespace CbChallenge.Core;

/// <summary>
/// Fetches and parses data from data sources.
/// </summary>
public abstract class Feed
{
    public abstract JsonArray GetObjects();
}