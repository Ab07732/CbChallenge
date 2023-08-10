namespace CbChallenge.Core;

/// <summary>
/// Base class for integrations that fetch data from data sources and load it into models.
/// </summary>
/// <remarks>
/// The integration class is the top-level object for an integration. It contains:
/// <list type="bullet">
///   <item>One or more <see cref="Feed">Feeds</see> that fetch and parse data from data sources</item>
///   <item>One or more <see cref="IImporter">Importers</see> that load data into models</item>
///   <item>A <see cref="DataSet" /> that stores the created model instances</item>
/// </list>
public abstract class Integration
{
    public DataSet DataSet { get; } = new DataSet();

    protected List<IImporter> _importers = new List<IImporter>();

    /// <summary>
    /// Runs the integration, populating this integration's <see cref="DataSet" />.
    /// </summary>
    public void Run()
    {
        foreach (var importer in this._importers)
        {
            importer.MapObjects();
        }
    }

    /// <summary>
    /// Registers an <see cref="IImporter" /> for use when this integration is run.
    /// </summary>
    protected void RegisterImporter<TImporter>()
        where TImporter : IImporter
    {
        var instance = Activator.CreateInstance(typeof(TImporter), new object[] { this }) as IImporter;
        this._importers.Add(instance!);
    }
}