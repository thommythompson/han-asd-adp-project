namespace ADPProject.Library.Interfaces;

public interface IMyGraph<T>
{
    public Dictionary<T, Vertex<T>> Vertices { get; }
    void AddVertex(T data);
    void AddEdge(T sourceData, T destinationData, int weight = 0);
    bool AreAdjacent(T sourceData, T destinationData);
    List<T> Neighbors(T vertexData);
    void RemoveVertex(T data);
    void RemoveEdge(T sourceData, T destinationData);
}