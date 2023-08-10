using System.Text.Json.Nodes;
using CbChallenge.Core;

namespace CbChallenge.Integrations.YourIntegration;

public class YourFeed : Feed
{
    // This initializer may have parameters added to it as needed
    public YourFeed()
    {
    }

    public override JsonArray GetObjects()
    {
        /* This method should:
         * 1. Fetch data from a JSON feed URL specified in the instructions
         * 2. Parse that data using System.Text.Json
         * 3. Retrieve the JsonArray containing the desired data from the parsed data
         * 3. Return the JsonArray
        */

        return new JsonArray();
    }
}
