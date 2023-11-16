using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDynamicArray
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyDynamicArray(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            array.Add(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.AddCount, array.Length);
    }

    [Fact]
    public void GetAsc()
    {
        IMyList<int> array = GetArray(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            _ = array.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void GetDesc()
    {
        IMyList<int> array = GetArray(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.GetCount - 1; i > 0; i--)
        {
            array.Get(i);
        }

        benchmarker.Stop();
    }

    [Fact]
    public void SetAsc()
    {
        IMyList<int> array = GetArray(Config.SetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.SetCount; i++)
        {
            array.Set(i, i + 1);
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void SetDesc()
    {
        IMyList<int> array = GetArray(Config.SetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.SetCount - 1; i > 0; i--)
        {
            array.Set(i, i + 1);
        }
        
        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByIndexZero()
    {
        IMyList<int> array = GetArray(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            array.RemoveByIndex(0);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, array.Length);
    }
    
    [Fact]
    public void RemoveByIndexDesc()
    {
        IMyList<int> array = GetArray(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            array.RemoveByIndex(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, array.Length);
    }

    [Fact]
    public void RemoveByValueAsc()
    {
        IMyList<int> array = GetArray(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            array.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, array.Length);
    }
    
    [Fact]
    public void RemoveByValueDesc()
    {
        IMyList<int> array = GetArray(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            array.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, array.Length);
    }

    private IMyList<int> GetArray(int size)
    {
        IMyList<int> array = new MyDynamicArray<int>();

        for (int i = 0; i < size; i++)
        {
            array.Add(i);
        }

        return array;
    }
}