namespace ADPProject.Library.Interfaces;

public interface IMyPriorityQueue<T> : IConvertableFromArray<T>
{
    void Insert(int priority, T item);
    T FindMin();
    T DeleteMin();
}