using System.Reflection;
using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class JsonFetcher : IDisposable
{
    private readonly string DataDirectoryName = "Data";
    
    private string DataDirectoryPath { get; init; }
        
    public JsonFetcher()
    {
        DataDirectoryPath = Path.Join(GetExecutingAssemblyDirectory(), DataDirectoryName);
    }

    public GraphDataset GetGraphDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, GraphDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<GraphDataset>(json);
        }
    }
    
    public HashingDataset GetHashingDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, HashingDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<HashingDataset>(json);
        }
    }
    
    public SortingDataset GetSortingDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, SortingDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<SortingDataset>(json);
        }
    }

    private string GetExecutingAssemblyDirectory()
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    public void Dispose()
    {
    }
}