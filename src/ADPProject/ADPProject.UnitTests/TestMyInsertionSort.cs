using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyInsertionSort
{
    [Fact]
    void Get()
    {
        IMySortedList<int> list = new MyInsertionSort<int>(GetList());

        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(2));
        Assert.Equal(50, list.Get(5));
    }


    private IMyList<int> GetList()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(10);
        list.Add(20);
        list.Add(3);
        list.Add(50);

        return list;
    }
}