namespace ADPProject.Library.Interfaces;

public interface IMyHashTable<TValue>
{
    public int Size { get; }
    void Add(string key, TValue value);
    IEnumerable<TValue> GetValuesForKey(string key);
    bool Remove(string key, TValue value);
}