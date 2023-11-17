using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class GraphDataset
{
    public static readonly string FileName = "dataset_grafen.json";
    
    [JsonProperty("lijnlijst")]
    public int[][] LijnLijst { get; set; }
    
    [JsonProperty("verbindingslijst")]
    public int[][] VerbindingsLijst { get; set; }
    
    [JsonProperty("verbindingsmatrix")]
    public int[][] VerbindingsMatrix { get; set; }
    
    [JsonProperty("lijnlijst_gewogen")]
    public int[][] LijnLijstGewogen { get; set; }
    
    [JsonProperty("verbindingslijst_gewogen")]
    public int[][][] VerbindingsLijstGewogen { get; set; }
    
    [JsonProperty("verbindingsmatrix_gewogen")]
    public int[][] VerbindingsMatrixGewogen { get; set; }
}