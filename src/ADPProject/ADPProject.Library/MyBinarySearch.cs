using System.Net;
using ADPProject.Library.Interfaces;

namespace ADPProject.Library;

public class MyBinarySearch<T> : IMyBinarySearch<T> where T : IComparable<T?>
{
    private IMySortedList<T> _list { get; init; }

    public MyBinarySearch(IMySortedList<T> list)
    {
        _list = list;
    }
    
    public MyBinarySearch()
    {
        _list = new MyInsertionSort<T>();
    }

    public int Search(T target)
    {
        int left = 0;
        int right = _list.Length - 1;

        while (left <= right)
        {
            int mid = left + ((right - left) / 2);
            
            int comparison = target.CompareTo(_list.Get(mid));

            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison > 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    public void ConvertFromArray(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var value = array[i];
            
            _list.Add(value);
        }
    }
}