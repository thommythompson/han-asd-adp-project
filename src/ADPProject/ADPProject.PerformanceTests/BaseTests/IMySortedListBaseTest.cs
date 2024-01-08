using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests.BaseTests;

public abstract class IMySortedListBaseTest
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public IMySortedListBaseTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyList<int> list = new MyDynamicArray<int>(); // Doubly linked list takes ages

        for (int i = 0; i < SortedListTestConfig.AddCount; i++)
        {
            list.Add(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);

        var mySortedList = GetMySortedList(list);
        
        benchmarker.Stop();
        
        Assert.Equal(SortedListTestConfig.AddCount, mySortedList.Length);
    }
    
    [Fact]
    public void AddSameNumbers()
    {
        IMyList<int> list = new MyDynamicArray<int>();

        for (int i = 0; i < SortedListTestConfig.AddCount; i++)
        {
            list.Add(1);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);

        var mySortedList = GetMySortedList(list);
        
        benchmarker.Stop();
        
        Assert.Equal(SortedListTestConfig.AddCount, mySortedList.Length);
    }

    [Fact]
    public void GetAsc()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < SortedListTestConfig.GetCount; i++)
        {
            _ = list.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void GetDesc()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = SortedListTestConfig.GetCount - 1; i > 0; i--)
        {
            list.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void GetSameNumbers()
    {
        IMyList<int> list = new MyDynamicArray<int>();

        for (int i = 0; i < SortedListTestConfig.GetCount; i++)
        {
            list.Add(1);
        }

        var mySortedList = GetMySortedList(list);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = SortedListTestConfig.GetCount - 1; i > 0; i--)
        {
            mySortedList.Get(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(SortedListTestConfig.GetCount, mySortedList.Length);
    }
    
    [Fact]
    public void RemoveByIndexZero()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < SortedListTestConfig.DeleteCount; i++)
        {
            list.RemoveByIndex(0);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByIndexDesc()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = SortedListTestConfig.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByIndex(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    [Fact]
    public void RemoveByValueAsc()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < SortedListTestConfig.DeleteCount; i++)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByValueDesc()
    {
        IMySortedList<int> list = GetList(SortedListTestConfig.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = SortedListTestConfig.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    private IMySortedList<int> GetList(int size)
    {
        IMyList<int> list = new MyDynamicArray<int>(); // Doubly linked list takes ages

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        IMySortedList<int> mySortedList = GetMySortedList(list);

        return mySortedList;
    }
    
    public abstract IMySortedList<T> GetMySortedList<T>(IMyList<T> list) where T : IComparable<T>;
}