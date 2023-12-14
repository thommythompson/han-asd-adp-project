using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MySelectionSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> List { get; set;  }
    
    public MySelectionSort(IMyList<T> list)
    {
        List = list;
        
        if (List.Length <= 1)
        {
            return;
        }

        Sort();
    }
    
    public MySelectionSort()
    {
        List = new MyDynamicArray<T>();
    }
    
    public IMyList<T> Sort()
    {
        for (int i = 0; i < List.Length - 1; i++)
        {
            int minIndex = i;
            
            for (int j = i + 1; j < List.Length; j++)
            {
                if (List.Get(j).CompareTo(List.Get(minIndex)) < 0)
                {
                    minIndex = j;
                }
            }
            
            Swap(List, minIndex, i);
        }

        return List;
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