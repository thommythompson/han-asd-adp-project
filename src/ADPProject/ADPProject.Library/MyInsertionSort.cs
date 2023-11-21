using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyInsertionSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> _list { get; }
    
    public MyInsertionSort(IMyList<T> list)
    {
        _list = list;
        
        if (_list.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MyInsertionSort()
    {
        _list = new MyDynamicArray<T>();
    }
    
    private IMyList<T> Sort()
    {
        for (int i = 1; i < _list.Length; i++)
        {
            T current = _list.Get(i);
            int j = i - 1;
            
            while (j >= 0 && _list.Get(j).CompareTo(current) > 0)
            {
                _list.Set(j + 1, _list.Get(j));
                j--;
            }

            _list.Set(j + 1, current);
        }

        return _list;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Length
    {
        get => _list.Length;
    }
    public void Add(T value)
    {
        _list.Add(value);
        Sort();
    }

    public T Get(int index)
    {
        return _list.Get(index);
    }

    public void RemoveByIndex(int index)
    {
        _list.RemoveByIndex(index);
        Sort();
    }

    public void RemoveByValue(T value)
    {
        _list.RemoveByValue(value);
        Sort();
    }

    public bool Contains(T value)
    {
        return _list.Contains(value);
    }

    public int IndexOf(T value)
    {
        return _list.IndexOf(value);
    }

    public void ConvertFromArray(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            this.Add(value);
        }
    }
}