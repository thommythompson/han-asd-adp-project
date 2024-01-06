using Newtonsoft.Json;

namespace ADPProject.Tests.Data;

public class HashingDataset
{
    public static readonly string FileName = "dataset_hashing.json";
    
    [JsonProperty("hashtabelsleutelswaardes")]
    public HashtabelSleutelWaardes HashTabelSleutelsWaardes { get; set; }
}

public class HashtabelSleutelWaardes
{
    public int[] a { get; init; }
    public int[] b { get; init; }
    public int[] c { get; init; }
    public int[] d { get; init; }
    public int[] e { get; init; }
    public int[] f { get; init; }
    public int[] g { get; init; }
    public int[] h { get; init; }
    public int[] i { get; init; }
    public int[] j { get; init; }
    public int[] k { get; init; }
    public int[] l { get; init; }
    public int[] m { get; init; }
    public int[] n { get; init; }
    public int[] o { get; init; }
    public int[] p { get; init; }
    public int[] q { get; init; }
    public int[] r { get; init; }
    public int[] s { get; init; }
    public int[] t { get; init; }
    public int[] u { get; init; }
    public int[] v { get; init; }
    public int[] w { get; init; }
    public int[] x { get; init; }
    public int[] y { get; init; }
    public int[] z { get; init; }
    public int[] z0 { get; init; }
}