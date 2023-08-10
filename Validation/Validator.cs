using CbChallenge.Core;
using CbChallenge.Integrations.YourIntegration;
using CbChallenge.Models;
using Xunit;

namespace CbChallenge.Validation;

public class Validator
{
    private Integration Integration = new YourIntegration();

    public void Validate()
    {
        var expected = new ExpectedDataSet();

        this.Integration.Run();

        CompareModels(expected.GetAll<Session>(), this.Integration.DataSet.GetAll<Session>());
        CompareModels(expected.GetAll<Speaker>(), this.Integration.DataSet.GetAll<Speaker>());
        CompareModels(expected.GetAll<Track>(), this.Integration.DataSet.GetAll<Track>());
    }

    private static void CompareModels<TModel>(TModel[] expectedModels, TModel[] actualModels)
    {
        var typeName = typeof(TModel).Name;

        Assert.True(
            expectedModels.Length == actualModels.Length,
            $"{expectedModels.Length} {typeName} instances were expected but {actualModels.Length} were received.");

        foreach ((var expected, var actual) in expectedModels.Zip(actualModels))
        {
            Assert.Equivalent(expected, actual, strict: true);
        }
    }
}