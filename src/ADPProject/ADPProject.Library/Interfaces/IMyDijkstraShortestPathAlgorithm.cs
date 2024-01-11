namespace ADPProject.Library.Interfaces;

public interface IMyDijkstraShortestPathAlgorithm<T>
{
    Dictionary<T, DijkstraTableRow<T>> GetShortestPathFrom(T start);
}