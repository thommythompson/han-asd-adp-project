using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class SortingDataset
{
    public static readonly string FileName = "dataset_sorteren.json";
    
    [JsonProperty("lijst_aflopend_2")]
    public int[] LijstAflopend2 { get; set; }
    
    [JsonProperty("lijst_oplopend_2")]
    public int[] LijstOplopend2 { get; set; }
    
    [JsonProperty("lijst_float_8001")]
    public float[] LijstFloat8001 { get; set; }
    
    [JsonProperty("lijst_willekeurig_3")]
    public float[] LijstWillekeurig { get; set; }
}