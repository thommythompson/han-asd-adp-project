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
            var Root = System.Reflection.Assembly.GetExecutingAssembly().Location;
            
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<GraphDataset>(json);
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