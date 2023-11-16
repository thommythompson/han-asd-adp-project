namespace ADPProject.Library;

public interface IMyDeque<T>
{
    int Size { get;  }
    void InsertLeft(T item);
    void InsertRight(T item);
    void DeleteLeft();
    void DeleteRight();
}

public class MyDeque<T> : IMyDeque<T>
{
    public int Size { get; }
    public void InsertLeft(T item)
    {
        throw new NotImplementedException();
    }

    public void InsertRight(T item)
    {
        throw new NotImplementedException();
    }

    public void DeleteLeft()
    {
        throw new NotImplementedException();
    }

    public void DeleteRight()
    {
        throw new NotImplementedException();
    }
}