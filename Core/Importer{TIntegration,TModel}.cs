using System.Text.Json.Nodes;

namespace CbChallenge.Core;

public abstract class Importer<TIntegration, TModel>
    : IImporter
    where TIntegration : Integration
    where TModel : IModel
{
    protected TIntegration Integration { get; init; }

    protected abstract Feed Feed { get; }

    public Importer(TIntegration integration)
    {
        this.Integration = integration;
    }

    public void MapObjects()
    {
        var objects = this.Feed.GetObjects();

        foreach (var obj in objects)
        {
            this.MapObjectAsync(obj!);
        }
    }

    protected abstract void MapObjectAsync(JsonNode obj);

    /// <summary>
    /// Finds or creates a <typeparamref name="TModel" /> instance by the specified ID.
    /// </summary>
    /// <param name="id">The ID by which the <typeparamref name="TModel" /> will be looked up.</param>
    /// <returns> The looked-up <typeparamref name="TModel" /> instance.</returns>
    protected TModel Lookup(string id) =>
        this.Integration.DataSet.Lookup<TModel>(id);
}