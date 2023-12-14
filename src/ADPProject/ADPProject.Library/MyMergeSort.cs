using System.Collections;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyMergeSort<T> : IMySortedList<T> where T : IComparable<T>
{
    private IMyList<T> List { get; }
    
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

            Task leftSort = MergeSort(list, left, mid);
            Task rightSort = MergeSort(list, mid + 1, right);

            await Task.WhenAll(leftSort, rightSort);

            Merge(list, left, mid, right);
        }
    }
    
    private void Merge(IMyList<T> list, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        T[] leftArray = list.Take(n1).ToArray();
        T[] rightArray = list.Skip(n1).Take(n2).ToArray();
        
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
                list.Set(k, leftArray[rightIndex]);
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
            list.Set(k, leftArray[rightIndex]);
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
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            this.Add(value);
        }
    }
}