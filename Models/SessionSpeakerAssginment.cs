namespace CbChallenge.Models;

/// <summary>
/// Describes the assignment of a <see cref="Speaker" /> to a <see cref="Session" />.
/// </summary>
public class SessionSpeakerAssignment
{
    public string SessionId { get; }

    public string SpeakerId { get; }

    public string? SpeakerRole { get; }

    public SessionSpeakerAssignment(string sessionId, string speakerId, string? speakerRole = null)
    {
        this.SessionId = sessionId;
        this.SpeakerId = speakerId;
        this.SpeakerRole = speakerRole;
    }

    public override bool Equals(object? obj) =>
        this.GetHashCode() == obj?.GetHashCode();

    public override int GetHashCode() =>
        HashCode.Combine(this.SessionId, this.SpeakerId, this.SpeakerRole);
}