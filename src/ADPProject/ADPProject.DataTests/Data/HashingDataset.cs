using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class HashingDataset
{
    public static readonly string FileName = "dataset_hashing.json";
    
    [JsonProperty("hashtabelsleutelswaardes")]
    public KeyValuePair<string, int[]> HashTabelSleutelsWaardes { get; set; }
}