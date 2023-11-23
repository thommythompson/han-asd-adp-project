using System.Collections.ObjectModel;
using System.Reflection;
using ADPProject.DataTests.Converters;
using ADPProject.Tests.Data;
using Newtonsoft.Json;

namespace ADPProject.DataTests.Helpers;

public class JsonFetcher : IDisposable
{
    private readonly string DataDirectoryName = "Data";
    
    private string DataDirectoryPath { get; init; }
        
    public JsonFetcher()
    {
        DataDirectoryPath = Path.Join(GetExecutingAssemblyDirectory(), DataDirectoryName);
    }

    public GraphDataset? GetGraphDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, GraphDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<GraphDataset>(json, GetConverterSettings());
        }
    }
    
    public HashingDataset? GetHashingDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, HashingDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<HashingDataset>(json, GetConverterSettings());
        }
    }
    
    public SortingDataset? GetSortingDataset()
    {
        var fileName = Path.Join(DataDirectoryPath, SortingDataset.FileName);
        
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<SortingDataset>(json, GetConverterSettings());
        }
    }

    private JsonSerializerSettings GetConverterSettings()
    {
        return new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new Collection<JsonConverter> { new NullableFloatArrayConverter(), new NullableIntArrayConverter() }
        };
    }
    
    private string? GetExecutingAssemblyDirectory()
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }

    public void Dispose()
    {
    }
}