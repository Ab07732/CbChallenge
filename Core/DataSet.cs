namespace CbChallenge.Core;

/// <summary>
/// Stores <see cref="IModel">Models</see> imported by <see cref="IImporter">Importers</see>.
/// </summary>
public class DataSet
{
    protected Dictionary<Type, ModelCollection> _store = new Dictionary<Type, ModelCollection>();

    public TModel Lookup<TModel>(string id)
        where TModel : IModel
    {
        var type = typeof(TModel);

        if (!this._store.TryGetValue(type, out var models))
        {
            models = this._store[type] = new ModelCollection();
        }

        if (!models.TryGetValue(id, out var model))
        {
            var created = Activator.CreateInstance(type, new[] { id });
            model = (IModel)created!;
            models.Add(model);
        }

        if (model is not null)
        {
            return (TModel)model!;
        }

        throw new Exception("DataSet.Lookup looked up a null model. (If you see this, the creator of the challenge probably messed up.)");
    }

    public TModel[] GetAll<TModel>()
        where TModel : IModel
    =>
        this._store.GetValueOrDefault(typeof(TModel))
        ?.Select(m => (TModel)m)
        .OrderBy(m => m.Id)
        .ToArray()
        ?? Array.Empty<TModel>();
}