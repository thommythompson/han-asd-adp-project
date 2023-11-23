namespace ADPProject.Library.Interfaces;

public interface IMyList<T> : IEnumerable<T>, IConvertableFromArray<T> where T : IComparable<T>
{
    public int Length { get; }
    public void Add(T value);
    public T Get(int index);
    public void Set(int index, T value);
    public void RemoveByIndex(int index);
    public void RemoveByValue(T value);
    public bool Contains(T value);
    public int IndexOf(T value);
}