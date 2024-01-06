using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDijkstraShortestPathAlgorithm
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyDijkstraShortestPathAlgorithm(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void FindShortestPath()
    {
        IMyGraph<char> graph = new MyGraph<char>();

        graph.AddVertex('A');
        graph.AddVertex('B');
        graph.AddVertex('C');
        graph.AddVertex('D');
        graph.AddVertex('E');
        graph.AddVertex('F');
        graph.AddVertex('G');
        graph.AddVertex('H');

        graph.AddEdge('A', 'B', 5);
        graph.AddEdge('A', 'C', 15);
        graph.AddEdge('A', 'D', 20);
        graph.AddEdge('B', 'E', 55);
        graph.AddEdge('C', 'F', 15);
        graph.AddEdge('D', 'G', 15);
        graph.AddEdge('E', 'H', 35);
        graph.AddEdge('F', 'H', 35);
        graph.AddEdge('G', 'H', 25);

        var dijkstra = new MyDijkstraShortestPathAlgorithm<char>(graph);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.MiscCount; i++)
        {
            _ = dijkstra.GetShortestPathFrom('A');
        }
        
        benchmarker.Stop();
    }
}