using System.Collections.ObjectModel;

namespace CbChallenge.Core;

public class ModelCollection : KeyedCollection<string, IModel>
{
    protected override string GetKeyForItem(IModel item) => item.Id;
}
