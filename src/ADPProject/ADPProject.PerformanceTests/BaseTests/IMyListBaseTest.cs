using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests.BaseTests;

public abstract class IMyListBaseTest
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public IMyListBaseTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyList<int> list = new MyDynamicArray<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            list.Add(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.AddCount, list.Length);
    }

    [Fact]
    public void GetAsc()
    {
        IMyList<int> list = GetList(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            _ = list.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void GetDesc()
    {
        IMyList<int> list = GetList(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.GetCount - 1; i > 0; i--)
        {
            list.Get(i);
        }

        benchmarker.Stop();
    }

    [Fact]
    public void SetAsc()
    {
        IMyList<int> list = GetList(Config.SetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.SetCount; i++)
        {
            list.Set(i, i + 1);
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void SetDesc()
    {
        IMyList<int> list = GetList(Config.SetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.SetCount - 1; i > 0; i--)
        {
            list.Set(i, i + 1);
        }
        
        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByIndexZero()
    {
        IMyList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            list.RemoveByIndex(0);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByIndexDesc()
    {
        IMyList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByIndex(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    [Fact]
    public void RemoveByValueAsc()
    {
        IMyList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByValueDesc()
    {
        IMyList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    private IMyList<int> GetList(int size)
    {
        IMyList<int> list = GetMyList<int>();

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        return list;
    }

    public abstract IMyList<T> GetMyList<T>() where T : IComparable<T>;
}