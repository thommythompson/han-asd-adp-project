using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MySelectionSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> _list { get; }
    
    public MySelectionSort(IMyList<T> list)
    {
        _list = list;
        
        if (_list.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MySelectionSort()
    {
        _list = new MyDynamicArray<T>();
    }
    
    public IMyList<T> Sort()
    {
        for (int i = 0; i < _list.Length - 1; i++)
        {
            int minIndex = i;
            
            for (int j = i + 1; j < _list.Length; j++)
            {
                if (_list.Get(j).CompareTo(_list.Get(minIndex)) < 0)
                {
                    minIndex = j;
                }
            }
            
            Swap(_list, minIndex, i);
        }

        return _list;
    }
    
    private void Swap(IMyList<T> list, int i, int j)
    {
        T temp = list.Get(i);
        list.Set(i, list.Get(j));
        list.Set(j, temp);
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