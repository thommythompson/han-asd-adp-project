using ADPProject.DataTests.Converters;
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
    
    [JsonProperty("lijst_gesorteerd_aflopend_3")]
    public int[] LijstGesorteerdAflopend3 { get; set; }
    
    [JsonProperty("lijst_gesorteerd_oplopend_3")]
    public int[] LijstGesorteerdOplopend3 { get; set; }
    
    [JsonProperty("lijst_herhaald_1000")]
    public int[] LijstHerhaald1000 { get; set; }
    
    [JsonProperty("lijst_leeg_0")]
    public int[] LijstLeeg0 { get; set; }
    
    [JsonProperty("lijst_null_1")]
    [JsonConverter(typeof(NullableIntArrayConverter))]
    public int[] LijstNull1 { get; set; }
    
    [JsonProperty("lijst_null_3")]
    [JsonConverter(typeof(NullableIntArrayConverter))]
    public int[] LijstNull3 { get; set; }
    
    [JsonProperty("lijst_onsorteerbaar_3")]
    public string[] LijstOnsorteerbaar3 { get; set; }
    
    [JsonProperty("lijst_oplopend_10000")]
    public int[] LijstOplopend10000 { get; set; }
    
    [JsonProperty("lijst_willekeurig_10000")]
    public int[] LijstWillekeurig10000 { get; set; }
    
    [JsonProperty("lijst_willekeurig_3")]
    public int[] LijstWillekeurig3 { get; set; }
}