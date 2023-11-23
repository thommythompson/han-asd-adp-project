using ADPProject.DataTests.Helpers;
using ADPProject.Tests.Data;

namespace ADPProject.Tests;

public class TestJsonFetcher
{
    [Fact]
    public void CanReadGraphDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            jsonFetcher.GetGraphDataset();
        }
    }
    
    [Fact]
    public void CanReadHashingDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            jsonFetcher.GetHashingDataset();
        }
    }
    
    [Fact]
    public void CanReadSortingDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            jsonFetcher.GetSortingDataset();
        }
    }
}