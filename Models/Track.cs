using CbChallenge.Core;

namespace CbChallenge.Models;

/// <summary>
/// Categorizes <see cref="Session">Sessions</see>.
/// </summary>
public class Track : IModel
{
    public string Id { get; }

    public string? Title { get; set; }

    public HashSet<SessionTrackAssignment> SessionAssignments { get; } = new HashSet<SessionTrackAssignment>();

    public Track(string id)
    {
        this.Id = id;
    }

    public void AssignSession(string sessionId)
    {
        this.SessionAssignments.Add(
            new SessionTrackAssignment(sessionId, this.Id));
    }
}