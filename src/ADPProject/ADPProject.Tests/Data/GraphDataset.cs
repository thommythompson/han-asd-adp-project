using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class GraphDataset
{
    public static readonly string FileName = "dataset_grafen.json";
    
    [JsonProperty("lijnlijst")]
    private int[][] LijnLijst { get; set; }
    
    [JsonProperty("verbindingslijst")]
    private int[][] VerbindingsLijst { get; set; }
    
    [JsonProperty("verbindingsmatrix")]
    private int[][] VerbindingsMatrix { get; set; }
    
    [JsonProperty("lijnlijst_gewogen")]
    private int[][] LijnLijstGewogen { get; set; }
    
    [JsonProperty("verbindingslijst_gewogen")]
    private int[][][] VerbindingsLijstGewogen { get; set; }
    
    [JsonProperty("verbindingsmatrix_gewogen")]
    private int[][] VerbindingsMatrixGewogen { get; set; }
}