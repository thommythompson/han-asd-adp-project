using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyDijkstraShortestPathAlgorithm<T> : IMyDijkstraShortestPathAlgorithm<T>
{
    private readonly IMyGraph<T> _graph;
    
    public MyDijkstraShortestPathAlgorithm(IMyGraph<T> graph)
    {
        _graph = graph;
    }
    
    public Dictionary<T, DijkstraTableRow<T>> GetShortestPathFrom(T start)
    {
        var distances = new Dictionary<T, DijkstraTableRow<T>>();
        var unvisited = new PriorityQueue<T, int>();

        foreach (var vertex in _graph.Vertices.Values)
        {
            distances[vertex.Data] = new DijkstraTableRow<T>(int.MaxValue, default(T));
            unvisited.Enqueue(vertex.Data, int.MaxValue);
        }

        distances[start].TotalDistance = 0;

        while (unvisited.Count > 0)
        {
            var currentVertex = unvisited.Dequeue();
            var current = _graph.Vertices[currentVertex];

            foreach (var edge in current.Edges)
            {
                var newDistance = distances[current.Data].TotalDistance + edge.Weight;
                if (newDistance < distances[edge.Destination.Data].TotalDistance)
                {
                    distances[edge.Destination.Data].TotalDistance = newDistance;
                    distances[edge.Destination.Data].PreviousVertex = current.Data;
                    unvisited.Enqueue(edge.Destination.Data, newDistance);
                }
            }
        }

        return distances;
    }
}

public class DijkstraTableRow<T>
{
    public int TotalDistance { get; set; }
    public T PreviousVertex { get; set; }

    public DijkstraTableRow(int totalDistance, T previousVertex)
    {
        TotalDistance = totalDistance;
        PreviousVertex = previousVertex;
    }
}