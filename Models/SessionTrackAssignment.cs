namespace CbChallenge.Models;

/// <summary>
/// Describes the assignment of a <see cref="Track" /> to a <see cref="Session" />.
/// </summary>
public class SessionTrackAssignment
{
    public string SessionId { get; }

    public string TrackId { get; }

    public SessionTrackAssignment(string sessionId, string trackId)
    {
        this.SessionId = sessionId;
        this.TrackId = trackId;
    }

    public override bool Equals(object? obj) =>
        this.GetHashCode() == obj?.GetHashCode();

    public override int GetHashCode() =>
        HashCode.Combine(this.SessionId, this.TrackId);
}