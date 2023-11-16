namespace ADPProject.Library.Interfaces;

public interface IMyPriorityQueue<T>
{
    void Add(T item);
    void Peek();
    void Poll();
    void Insert();
    void FindMin();
    void DeleteMin();
}