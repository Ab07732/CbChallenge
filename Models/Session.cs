using CbChallenge.Core;

namespace CbChallenge.Models;

/// <summary>
/// Describe a session that's a scheduled part of an event, meeting, trade show, etc.
/// </summary>
public class Session : IModel
{
    public string Id { get; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public Session(string id)
    {
        this.Id = id;
    }
}