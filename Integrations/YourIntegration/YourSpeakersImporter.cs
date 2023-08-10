using System.Text.Json.Nodes;
using CbChallenge.Core;
using CbChallenge.Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;

namespace CbChallenge.Integrations.YourIntegration;

public class YourSpeakersImporter : Importer<YourIntegration, Speaker>

{
    protected override Feed Feed { get => this.Integration.SpeakersFeed; }

    public YourSpeakersImporter(YourIntegration integration)
        : base(integration)
    {
    }

    protected override async Task<T?> MapObjectAsync(JsonNode obj)
    {
        /* This method should:
         * 1. Get the speaker's ID from obj, then use the ID to lookup a Speaker instance
         * 2. Populate the speaker instance's fields from the data contained in obj
         * 3. Assign the Speaker instance to one or more Sessions based on the data contained in obj
         * (There's no need to save the changes to Speaker, this.Lookup keeps track of the instaces it creates.)
         */
        using (HttpResponseMessage response = await HttpClient.GetAsync(https://static.coreapps.net/communitybrands-integration-challenge/sessions.json );

            {
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                T parsedData = JsonConvert.DeserializeObject<T>(jsonResponse);
                return parsedData;
            }
            else
            {
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                return default; // or throw an exception
            }
        }
    }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default; // or throw an exception
        }

var id = (string)obj["id"]!;
        var speaker = this.Lookup(id);

        speaker.Name = "";

        speaker.AssignSession("");
    }
}