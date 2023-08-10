using CbChallenge.Core;
using CbChallenge.Models;
using System.Text.Json.Nodes;

namespace CbChallenge.Integrations.YourIntegration;

public class YourTracksImporter : Importer<YourIntegration, Track>
{
    protected override Feed Feed { get => this.Integration.TracksFeed; }

    public YourTracksImporter(YourIntegration integration) : base(integration)
    {

    }

    protected override void MapObjectAsync(JsonNode obj)
    {
        /* This method should:
//         * 1. Get the speaker's ID from obj, then use the ID to lookup a Speaker instance
//         * 2. Populate the speaker instance's fields from the data contained in obj
//         * 3. Assign the Speaker instance to one or more Sessions based on the data contained in obj
//         * (There's no need to save the changes to Speaker, this.Lookup keeps track of the instaces it creates.)
//         */

        var id = (string)obj["id"];
        var track = this.Lookup(id);

        track.Title = "";
        track.AssignSession("");

    }
}


