using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyGraph<T> : IMyGraph<T>
{
    public Dictionary<T, Vertex<T>> Vertices { get; private set; }

    public MyGraph()
    {
        Vertices = new Dictionary<T, Vertex<T>>();
    }
    
    public void AddVertex(T data)
    {
        if (!Vertices.ContainsKey(data))
        {
            Vertices[data] = new Vertex<T>(data);
            return;
        }
        throw new Exception("Vertex already exists in the graph.");
    }

    public void AddEdge(T sourceData, T destinationData, int weight = 0)
    {
        if (Vertices.ContainsKey(sourceData) && Vertices.ContainsKey(destinationData))
        {
            Vertex<T> sourceVertex = Vertices[sourceData];
            Vertex<T> destinationVertex = Vertices[destinationData];

            sourceVertex.Edges.Add(new Edge<T>(destinationVertex, weight));
            return;
        }
        throw new Exception("Source or destination vertex does not exist.");
    }
    
    public bool AreAdjacent(T sourceData, T destinationData)
    {
        if (Vertices.ContainsKey(sourceData) && Vertices.ContainsKey(destinationData))
        {
            Vertex<T> sourceVertex = Vertices[sourceData];

            foreach (var edge in sourceVertex.Edges)
            {
                if (edge.Destination.Data.Equals(destinationData))
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    public List<T> Neighbors(T vertexData)
    {
        List<T> neighbors = new List<T>();

        if (Vertices.ContainsKey(vertexData))
        {
            Vertex<T> vertex = Vertices[vertexData];
            foreach (var edge in vertex.Edges)
            {
                neighbors.Add(edge.Destination.Data);
            }
            return neighbors;
        }

        throw new Exception("Vertex not found.");
    }
    
    public void RemoveVertex(T data)
    {
        if (Vertices.ContainsKey(data))
        {
            Vertices.Remove(data);

            foreach (var vertex in Vertices.Values)
            {
                var edgesToRemove = vertex.Edges.FindAll(e => e.Destination.Data.Equals(data));
                foreach (var edgeToRemove in edgesToRemove)
                {
                    vertex.Edges.Remove(edgeToRemove);
                }
            }
            return;
        }
        throw new Exception("Vertex not found.");
    }

    public void RemoveEdge(T sourceData, T destinationData)
    {
        if (Vertices.ContainsKey(sourceData) && Vertices.ContainsKey(destinationData))
        {
            Vertex<T> sourceVertex = Vertices[sourceData];

            Edge<T> edgeToRemove = sourceVertex.Edges.Find(e => e.Destination.Data.Equals(destinationData));
            if (edgeToRemove != null)
            {
                sourceVertex.Edges.Remove(edgeToRemove);
                return;
            }
            throw new Exception("Edge not found.");
        }
        throw new Exception("Source or destination vertex does not exist.");
    }
}

public class Vertex<T>
{
    public T Data { get; set; }
    public List<Edge<T>> Edges { get; set; }

    public Vertex(T data)
    {
        Data = data;
        Edges = new List<Edge<T>>();
    }
}

public class Edge<T>
{
    public Vertex<T> Destination { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex<T> destination, int weight)
    {
        Destination = destination;
        Weight = weight;
    }
}