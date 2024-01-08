using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyHashTable<TValue> : IMyHashTable<TValue>
{
    public int Size { get; private set; } = 0;
    private const int DefaultCapacity = 7919;
    private readonly LinkedList<KeyValuePair<string, TValue>>[] _buckets;

    public MyHashTable()
    {
        _buckets = new LinkedList<KeyValuePair<string, TValue>>[DefaultCapacity];
    }

    private int GetBucketIndex(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c * key.Length;
        }
        return Math.Abs(hash) % _buckets.Length;
    }

    public void Add(string key, TValue value)
    {
        int index = GetBucketIndex(key);
        if (_buckets[index] == null)
        {
            _buckets[index] = new LinkedList<KeyValuePair<string, TValue>>();
        }

        _buckets[index].AddLast(new KeyValuePair<string, TValue>(key, value));
        Size++;
    }

    public IEnumerable<TValue> GetValuesForKey(string key)
    {
        int index = GetBucketIndex(key);
        var values = new List<TValue>();

        foreach (var pair in _buckets[index])
        {
            if (pair.Key.Equals(key))
            {
                values.Add(pair.Value);
            }
        }

        return values;
    }

    public bool Remove(string key, TValue value)
    {
        int index = GetBucketIndex(key);
        KeyValuePair<string, TValue> searchPair = new KeyValuePair<string, TValue>(key, value);

        bool lastRemoved;
        bool removed = lastRemoved = _buckets[index].Remove(searchPair);
        if (lastRemoved)
        {
            Size--;
        }
        while (lastRemoved)
        {
            lastRemoved = _buckets[index].Remove(searchPair);
            if (lastRemoved)
            {
                Size--;
            }
        }

        return removed;
    }
}