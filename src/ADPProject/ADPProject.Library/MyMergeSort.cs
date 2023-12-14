using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyMergeSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> List { get; set;  }
    
    public MyMergeSort(IMyList<T> list)
    {
        List = list;
        
        if (List.Length <= 1)
        {
            return;
        }

        Sort().Wait();
    }
    
    public MyMergeSort()
    {
        List = new MyDynamicArray<T>();
    }
    
    private async Task<IMyList<T>> Sort()
    {
        if (List.Length <= 1)
            return List;

        await MergeSort(List, 0, List.Length - 1);

        return List;
    }

    private async Task MergeSort(IMyList<T> list, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            await MergeSort(list, left, mid);
            await MergeSort(list, mid + 1, right);

            Merge(list, left, mid, right);
        }
    }

    private void Merge(IMyList<T> list, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        T[] leftArray = new T[n1];
        T[] rightArray = new T[n2];

        for (int i = 0; i < n1; i++)
            leftArray[i] = list.Get(left + i);

        for (int j = 0; j < n2; j++)
            rightArray[j] = list.Get(mid + 1 + j);

        int k = left;
        int leftIndex = 0, rightIndex = 0;

        while (leftIndex < n1 && rightIndex < n2)
        {
            if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
            {
                list.Set(k, leftArray[leftIndex]);
                leftIndex++;
            }
            else
            {
                list.Set(k, rightArray[rightIndex]);
                rightIndex++;
            }
            k++;
        }

        while (leftIndex < n1)
        {
            list.Set(k, leftArray[leftIndex]);
            leftIndex++;
            k++;
        }

        while (rightIndex < n2)
        {
            list.Set(k, rightArray[rightIndex]);
            rightIndex++;
            k++;
        }
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
        Sort().Wait();
    }

    public T Get(int index)
    {
        return List.Get(index);
    }

    public void RemoveByIndex(int index)
    {
        List.RemoveByIndex(index);
        Sort().Wait();
    }

    public void RemoveByValue(T value)
    {
        List.RemoveByValue(value);
        Sort().Wait();
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