using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyDijkstraShortestPathAlgorithm<T> : IMyDijkstraShortestPathAlgorithm<T>
{
    private readonly IMyGraph<T> _graph;
    
    public MyDijkstraShortestPathAlgorithm(IMyGraph<T> graph)
    {
        _graph = graph;
    }
    
    public Dictionary<T, int> GetShortestPathFrom(T start)
    {
        var distances = new Dictionary<T, int>();
        var stack = new Stack<Vertex<T>>();

        foreach (var vertex in _graph.Vertices)
        {
            distances[vertex.Key] = int.MaxValue;
        }

        distances[start] = 0;
        stack.Push(_graph.Vertices[start]);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            foreach (var edge in current.Edges)
            {
                var altDistance = distances[current.Data] + edge.Weight;
                if (altDistance < distances[edge.Destination.Data])
                {
                    distances[edge.Destination.Data] = altDistance;
                    stack.Push(edge.Destination);
                }
            }
        }

        return distances;
    }
}