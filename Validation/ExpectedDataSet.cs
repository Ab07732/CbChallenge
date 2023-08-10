using CbChallenge.Core;
using CbChallenge.Models;

namespace CbChallenge.Validation;

public class ExpectedDataSet : DataSet
{
    private static readonly Speaker[] _expectedSpeakers = new Speaker[]
    {
        new Speaker("1")
        {
            Name = "Person One",
            Biography = "Lorem ipsum dolor sit amet",
            Prefix = "Dr.",
            Suffix = "PhD",
            Title = "Example Title",
            Company = "Example Company A",
        },
        new Speaker("2")
        {
            Name = "Person Two",
            Biography = "Lorem ipsum dolor sit amet",
            Prefix = "Mx.",
            Title = "Example Title",
            Company = "Example Company A",
        },
        new Speaker("3")
        {
            Name = "Person Three",
            Biography = "Lorem ipsum dolor sit amet",
            Prefix = "Ms.",
            Title = "Example Title",
            Company = "Example Company A",
        },
        new Speaker("4")
        {
            Name = "Person Four",
            Biography = "Lorem ipsum dolor sit amet",
            Prefix = "Mr.",
            Title = "Example Title",
            Company = "Example Company B",
        },
        new Speaker("5")
        {
            Name = "Person Five",
            Biography = "Lorem ipsum dolor sit amet",
            Prefix = "Mrs.",
            Title = "Example Title",
            Company = "Example Company B",
        },
    };

    private static readonly Track[] _expectedTracks = new Track[]
    {
        new Track("Track One")
        {
            Title = "Track One",
        },
        new Track("Track Two")
        {
            Title = "Track Two",
        },
        new Track("Track Three")
        {
            Title = "Track Three",
        },
        new Track("Track Four")
        {
            Title = "Track Four",
        },
        new Track("Track Five")
        {
            Title = "Track Five",
        },
        new Track("Example Company A Speakers")
        {
            Title = "Example Company A Speakers",
        },
        new Track("Example Company B Speakers")
        {
            Title = "Example Company B Speakers",
        },
    };

    private static readonly Session[] _expectedSessions = new Session[]
    {
        new Session("1")
        {
            Title = "Session One",
            Description = "Lorem ipsum dolor sit amet",
            Location = "Example Location",
            Start = new DateTime(2025, 1, 1, 12, 0, 0),
            End = new DateTime(2025, 1, 1, 13, 0, 0),
        },
        new Session("2")
        {
            Title = "Session Two",
            Description = "Lorem ipsum dolor sit amet",
            Location = "Example Location",
            Start = new DateTime(2025, 1, 1, 13, 0, 0),
            End = new DateTime(2025, 1, 1, 14, 0, 0),
        },
        new Session("3")
        {
            Title = "Session Three",
            Description = "Lorem ipsum dolor sit amet",
            Location = "Example Location",
            Start = new DateTime(2025, 1, 1, 14, 0, 0),
            End = new DateTime(2025, 1, 1, 15, 0, 0),
        },
        new Session("4")
        {
            Title = "Session Four",
            Description = "Lorem ipsum dolor sit amet",
            Location = "Example Location",
            Start = new DateTime(2025, 1, 2, 12, 0, 0),
            End = new DateTime(2025, 1, 2, 13, 0, 0),
        },
        new Session("5")
        {
            Title = "Session Five",
            Description = "Lorem ipsum dolor sit amet",
            Location = "Example Location",
            Start = new DateTime(2025, 1, 2, 13, 0, 0),
            End = new DateTime(2025, 1, 2, 15, 30, 0),
        },
    };

    public ExpectedDataSet()
    {
        this.InsertExpected<Speaker>(_expectedSpeakers);
        this.InsertExpected<Track>(_expectedTracks);
        this.InsertExpected<Session>(_expectedSessions);
        this.CreateAssignments();
    }

    private void InsertExpected<TModel>(TModel[] models)
        where TModel : IModel
    {
        var modelCollection = this._store[typeof(TModel)] = new ModelCollection();

        foreach (var model in models)
        {
            modelCollection.Add(model);
        }
    }

    private void CreateAssignments()
    {
        this.Lookup<Speaker>("1").AssignSession("1");
        this.Lookup<Speaker>("2").AssignSession("2");
        this.Lookup<Speaker>("3").AssignSession("3", speakerRole: "Presenting Author");
        this.Lookup<Speaker>("4").AssignSession("4", speakerRole: "Moderator");
        this.Lookup<Speaker>("4").AssignSession("5", speakerRole: "Chair");
        this.Lookup<Speaker>("5").AssignSession("4", speakerRole: "Chair");
        this.Lookup<Speaker>("5").AssignSession("5", speakerRole: "Moderator");

        this.Lookup<Track>("Track One").AssignSession("1");
        this.Lookup<Track>("Track Two").AssignSession("2");
        this.Lookup<Track>("Track Three").AssignSession("3");
        this.Lookup<Track>("Track Four").AssignSession("4");

        this.Lookup<Track>("Track Five").AssignSession("3");
        this.Lookup<Track>("Track Five").AssignSession("4");
        this.Lookup<Track>("Track Five").AssignSession("5");

        this.Lookup<Track>("Example Company A Speakers").AssignSession("1");
        this.Lookup<Track>("Example Company A Speakers").AssignSession("2");
        this.Lookup<Track>("Example Company A Speakers").AssignSession("3");
        this.Lookup<Track>("Example Company B Speakers").AssignSession("4");
        this.Lookup<Track>("Example Company B Speakers").AssignSession("5");
    }
}
