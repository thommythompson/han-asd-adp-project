namespace ADPProject.Library.Interfaces;

public interface IMyDeque<T>
{
    int Size { get;  }
    void InsertLeft(T item);
    void InsertRight(T item);
    T DeleteLeft();
    T DeleteRight();
}