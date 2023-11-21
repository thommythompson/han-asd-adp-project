namespace ADPProject.Library.Interfaces;

public interface IMySortedList<T> : IEnumerable<T>, IConvertableFromArray<T>
{
    public int Length { get; }
    public void Add(T value);
    public T Get(int index);
    public void RemoveByIndex(int index);
    public void RemoveByValue(T value);
    public bool Contains(T value);
    public int IndexOf(T value);
}