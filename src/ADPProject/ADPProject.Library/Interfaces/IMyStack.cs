namespace ADPProject.Library.Interfaces;

public interface IMyStack<T>
{
    int Size { get; }
    void Push(T item);
    T Pop();
    T Top();
    T Peek();
    bool IsEmpty();
}