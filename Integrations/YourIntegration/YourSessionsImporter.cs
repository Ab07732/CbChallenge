using CbChallenge.Core;
using CbChallenge.Models;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace CbChallenge.Integrations.YourIntegration;
    public class YourSessionsImporter : Importer<YourIntegration, Session>
    {
        protected override Feed Feed { get => this.Integration.SessionsFeed; }

        public YourSessionsImporter(YourIntegration integration) : base(integration)
        {

        }

        protected override async Task<object?> MapObjectAsync(JsonNode obj)
        {


        /* This method should:
         * 1. Get the speaker's ID from obj, then use the ID to lookup a Speaker instance
         * 2. Populate the speaker instance's fields from the data contained in obj
         * 3. Assign the Speaker instance to one or more Sessions based on the data contained in obj
         * (There's no need to save the changes to Speaker, this.Lookup keeps track of the instaces it creates.)
         */

        try
        {

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
        var id = (string)obj["id"];
            var session = this.Lookup(id);

        session.Title = "";

        session.Location = "";


        }

    }
