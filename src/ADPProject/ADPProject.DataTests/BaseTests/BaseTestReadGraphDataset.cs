using ADPProject.DataTests.Helpers;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests.BaseTests;

public abstract class BaseTestReadGraphDataset
{
    private GraphDataset? _dataset { get; init; } 
    
    public BaseTestReadGraphDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetGraphDataset();
        }
    }

    [Fact]
    public void CanReadLijnLijst()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.LijnLijst;
        
        var vertices = data.SelectMany(x => x).Distinct().ToList();
        foreach (var vertex in vertices.Distinct())
        {
            myGraph.AddVertex(vertex);
        }
        
        foreach (var lijn in data)
        {
            var vertex1 = lijn[0];
            var vertex2 = lijn[1];
            
            myGraph.AddEdge(vertex1, vertex2);
            myGraph.AddEdge(vertex2, vertex1);
        }
    }
    
    [Fact]
    public void CanReadVerbindingsLijst()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.VerbindingsLijst;
        
        for (int i = 0; i < data.Length; i++)
        {
            myGraph.AddVertex(i);
        }

        for (int i = 0; i < data.Length; i++)
        {
            foreach (var dst in data[i])
            {
                myGraph.AddEdge(i, dst);
            }
        }
    }

    [Fact]
    public void CanReadVerbindingsMatrix()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.VerbindingsMatrix;
        
        for (int i = 0; i < data.Length; i++)
        {
            myGraph.AddVertex(i); 
        }
        
        for (int i = 0; i < data.Length; i++)
        {
            var array = data[i];
            for (int y = 0; y < array.Length; y++)
            {
                if (array[y] != 0)
                {
                    myGraph.AddEdge(i, y);
                }
            }
        }
    }
    
    [Fact]
    public void CanReadLijnLijstGewogen()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.LijnLijstGewogen;

        var vertices = data.SelectMany(x => x).Distinct().ToList();
        foreach (var vertex in vertices.Distinct())
        {
            myGraph.AddVertex(vertex);
        }
        
        foreach (var lijn in data)
        {
            var vertex1 = lijn[0];
            var vertex2 = lijn[1];
            var weight = lijn[2];
            
            myGraph.AddEdge(vertex1, vertex2, weight);
            myGraph.AddEdge(vertex2, vertex1, weight);
        }
    }
    
    [Fact]
    public void CanReadVerbindingsLijstGewogen()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.VerbindingsLijstGewogen;
        
        for (int i = 0; i < data.Length; i++)
        {
            myGraph.AddVertex(i);
        }

        for (int i = 0; i < data.Length; i++)
        {
            foreach (var edge in data[i])
            {
                var dst = edge[0];
                var weight = edge[1];
                myGraph.AddEdge(i, dst, weight);
            }
        }
    }
    
    [Fact]
    public void CanReadVerbindingsMatrixGewogen()
    {
        IMyGraph<int> myGraph = CreateIntGraph();
        var data = _dataset.VerbindingsMatrixGewogen;
        
        for (int i = 0; i < data.Length; i++)
        {
            myGraph.AddVertex(i); 
        }
        
        for (int i = 0; i < data.Length; i++)
        {
            var array = data[i];
            for (int y = 0; y < array.Length; y++)
            {
                var weight = array[y];
                if (weight != 0)
                {
                    myGraph.AddEdge(i, y, weight);
                }
            }
        }
    }

    public abstract IMyGraph<int> CreateIntGraph();
}