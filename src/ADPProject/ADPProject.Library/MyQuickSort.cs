using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyQuickSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> List { get; set;  }
    
    public MyQuickSort(IMyList<T> list)
    {
        List = list;
        
        if (List.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MyQuickSort()
    {
        List = new MyDynamicArray<T>();
    }
    
    private IMyList<T> Sort()
    {
        if (List.Length <= 1)
            return List;

        QuickSort(List, 0, List.Length - 1);

        return List;
    }

    private void QuickSort(IMyList<T> list, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(list, left, right);

            QuickSort(list, left, pivotIndex - 1);
            QuickSort(list, pivotIndex + 1, right);
        }
    }

    private int Partition(IMyList<T> list, int left, int right)
    {
        int pivotIndex = DeterminePivotIndex(list, left, right);
        T pivot = list.Get(pivotIndex);
        Swap(list, pivotIndex, right);

        int i = left;
        for (int j = left; j < right; j++)
        {
            if (list.Get(j).CompareTo(pivot) <= 0)
            {
                Swap(list, i, j);
                i++;
            }
        }
        Swap(list, i, right);

        return i;
    }

    private int DeterminePivotIndex(IMyList<T> list, int left, int right)
    {
        int mid = (left + right) / 2;

        T a = list.Get(left);
        T b = list.Get(mid);
        T c = list.Get(right);

        if ((a.CompareTo(b) >= 0 && a.CompareTo(c) <= 0) || (a.CompareTo(b) <= 0 && a.CompareTo(c) >= 0))
            return left;
        if ((b.CompareTo(a) >= 0 && b.CompareTo(c) <= 0) || (b.CompareTo(a) <= 0 && b.CompareTo(c) >= 0))
            return mid;

        return right;
    }

    private void Swap(IMyList<T> list, int i, int j)
    {
        T temp = list.Get(i);
        list.Set(i, list.Get(j));
        list.Set(j, temp);
    }

    
    public IEnumerator<T> GetEnumerator()
    {
        return List.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Length
    {
        get => List.Length;
    }
    
    public void Add(T value)
    {
        List.Add(value);
        Sort();
    }

    public T Get(int index)
    {
        return List.Get(index);
    }

    public void RemoveByIndex(int index)
    {
        List.RemoveByIndex(index);
        Sort();
    }

    public void RemoveByValue(T value)
    {
        List.RemoveByValue(value);
        Sort();
    }

    public bool Contains(T value)
    {
        return List.Contains(value);
    }

    public int IndexOf(T value)
    {
        return List.IndexOf(value);
    }

    public void ConvertFromArray(T[] array)
    {
        List = new MyDynamicArray<T>();
        
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            List.Add(value);
        }

        Sort();
    }
}