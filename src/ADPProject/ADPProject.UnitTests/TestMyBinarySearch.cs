using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyBinarySearch
{
    [Fact]
    public void Search()
    {
        IMyList<int> list = new MyDynamicArray<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(6);
        list.Add(7);
        list.Add(8);
        list.Add(4);
        list.Add(5);
        list.Add(9);
        list.Add(10);

        IMySortedList<int> sortedList = new MyInsertionSort<int>(list);

        IMyBinarySearch<int> binarySearch = new MyBinarySearch<int>(sortedList);

        var result = binarySearch.Search(5);
        
        Assert.Equal(4, result);
    }
}