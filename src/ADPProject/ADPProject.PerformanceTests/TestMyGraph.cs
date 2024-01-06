using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyGraph
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyGraph(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void AddVertices()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            graph.AddVertex(i);
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void AddVerticesAndEdges()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            graph.AddVertex(i);
        }

        var prev = 0;
        for (int i = 1; i < Config.AddCount; i++)
        {
            graph.AddEdge(prev,i);
            prev++;
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void TestAdjactent()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        for (int i = 0; i < Config.MiscCount; i++)
        {
            graph.AddVertex(i);
        }

        var prev = 0;
        for (int i = 1; i < Config.MiscCount; i++)
        {
            graph.AddEdge(prev,i);
            prev++;
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        prev = 0;
        for (int i = 10; i < Config.MiscCount; i++)
        {
            graph.AreAdjacent(prev,i);
            prev++;
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void TestNeighbors()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        for (int i = 0; i < Config.MiscCount; i++)
        {
            graph.AddVertex(i);
        }

        var prev = 0;
        for (int i = 1; i < Config.MiscCount; i++)
        {
            graph.AddEdge(prev,i);
            prev++;
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 1; i < Config.MiscCount; i++)
        {
            _ = graph.Neighbors(i);
            prev++;
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void TestRemoveVertex()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            graph.AddVertex(i);
        }

        var prev = 0;
        for (int i = 1; i < Config.DeleteCount; i++)
        {
            graph.AddEdge(prev,i);
            prev++;
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            graph.RemoveVertex(i);
            prev++;
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void TestRemoveEdge()
    {
        IMyGraph<int> graph = new MyGraph<int>();
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            graph.AddVertex(i);
        }

        var prev = 0;
        for (int i = 1; i < Config.DeleteCount; i++)
        {
            graph.AddEdge(prev,i);
            prev++;
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        prev = 0;
        for (int i = 1; i < Config.DeleteCount; i++)
        {
            graph.RemoveEdge(prev,i);
            prev++;
        }
        
        benchmarker.Stop();
    }
}