using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyInsertionSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> List { get; set; }
    
    public MyInsertionSort(IMyList<T> list)
    {
        List = list;
        
        if (List.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MyInsertionSort()
    {
        List = new MyDynamicArray<T>();
    }
    
    private IMyList<T> Sort()
    {
        for (int i = 1; i < List.Length; i++)
        {
            T current = List.Get(i);
            int j = i - 1;
            
            while (j >= 0 && List.Get(j).CompareTo(current) > 0)
            {
                List.Set(j + 1, List.Get(j));
                j--;
            }

            List.Set(j + 1, current);
        }

        return List;
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