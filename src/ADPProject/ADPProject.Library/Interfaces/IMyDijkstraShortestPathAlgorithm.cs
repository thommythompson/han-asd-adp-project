namespace ADPProject.Library.Interfaces;

public interface IMyDijkstraShortestPathAlgorithm<T>
{
    Dictionary<T, int> GetShortestPathFrom(T start);
}