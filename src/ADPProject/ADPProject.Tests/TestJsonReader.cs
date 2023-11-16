using ADPProject.Tests.Data;

namespace ADPProject.Tests;

public class TestJsonReader
{
    [Fact]
    public void CanReadGraphDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            jsonFetcher.GetGraphDataset();
        }
    }
}