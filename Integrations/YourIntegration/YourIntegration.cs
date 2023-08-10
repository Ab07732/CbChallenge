using CbChallenge.Core;


namespace CbChallenge.Integrations.YourIntegration
{

    public class YourIntegration : Integration
    {
        public Feed SpeakersFeed { get; protected set; }
        public Feed SessionsFeed { get; protected set; }
        public Feed TracksFeed { get; protected set; }

        // Additional Feed properties may be added here

        public YourIntegration()
            : base()
        {
            this.SpeakersFeed = new YourFeed();
            // Additional Feeds may be initialized here
            this.SessionsFeed = new YourFeed();
            this.TracksFeed = new YourFeed();

            this.RegisterImporter<YourSpeakersImporter>();
            this.RegisterImporter<YourSessionsImporter>();
            this.RegisterImporter<YourTracksImporter>();
            // Additional Importers may be registered here
            // Note: Multiple importers for the same Model type may be registered if needed
        }
    }
}