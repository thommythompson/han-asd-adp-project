using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyQuickSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> _list { get; }
    
    public MyQuickSort(IMyList<T> list)
    {
        _list = list;
        
        if (_list.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MyQuickSort()
    {
        _list = new MyDynamicArray<T>();
    }
    
    private IMyList<T> Sort()
    {
        if (_list.Length <= 1)
            return _list;

        QuickSort(_list, 0, _list.Length - 1);

        return _list;
    }
    
    private void QuickSort(IMyList<T> list, int left, int right)
    {
        if (left < right)
        {
            int partitionIndex = Partition(list, left, right);

            QuickSort(list, left, partitionIndex - 1);
            QuickSort(list, partitionIndex + 1, right);
        }
    }
    
    private int Partition(IMyList<T> list, int left, int right)
    {
        T pivot = list.Get(right);
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (list.Get(j).CompareTo(pivot) <= 0)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, right);
        return i + 1;
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