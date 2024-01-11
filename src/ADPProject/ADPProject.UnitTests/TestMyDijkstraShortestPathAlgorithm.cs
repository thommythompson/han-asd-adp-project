using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyDijkstraShortestPathAlgorithm
{
    [Fact]
    public void GetShortestPath()
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

        var paths = dijkstra.GetShortestPathFrom('A');

        var expected = new Dictionary<char , DijkstraTableRow<char>> { { 'H', new DijkstraTableRow<char>(60, 'G') } };

        Assert.Contains(paths, expected.Contains);
    }
}