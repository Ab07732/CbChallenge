using CbChallenge.Core;

namespace CbChallenge.Models;

/// <summary>
/// Describes details about a person that speaks (or otherwise participates in) a <see cref="Session" />.
/// </summary>
public class Speaker : IModel
{
    public string Id { get; }

    public string? Name { get; set; }

    public string? Prefix { get; set; }

    public string? Suffix { get; set; }

    public string? Biography { get; set; }

    public string? Title { get; set; }

    public string? Company { get; set; }

    public HashSet<SessionSpeakerAssignment> SessionAssignments { get; } = new HashSet<SessionSpeakerAssignment>();

    public Speaker(string id)
    {
        this.Id = id;
    }

    public void AssignSession(string sessionId, string? speakerRole = null)
    {
        this.SessionAssignments.Add(
            new SessionSpeakerAssignment(sessionId, this.Id, speakerRole: speakerRole));
    }
}