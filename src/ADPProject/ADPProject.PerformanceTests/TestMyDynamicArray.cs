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
        
        for (int i = 0; i < Config.TestSize; i++)
        {
            array.Add(i);
        }
        
        benchmarker.Stop();
    }

    [Fact]
    public void Get()
    {
        IMyList<int> array = GetArray();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        _ = array.Get(Config.GetIndex);
        
        benchmarker.Stop();
    }

    [Fact]
    public void Set()
    {
        IMyList<int> array = GetArray();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        array.Set(Config.SetIndex, Config.SetValue);
        
        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByIndex()
    {
        IMyList<int> array = GetArray();

        var benchmarker = new Benchmarker(_outputHelper);

        array.RemoveByIndex(Config.RemoveIndex);

        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByValue()
    {
        IMyList<int> array = GetArray();

        var benchmarker = new Benchmarker(_outputHelper);

        array.RemoveByValue(Config.RemoveValue);

        benchmarker.Stop();
    }

    private IMyList<int> GetArray()
    {
        IMyList<int> array = new MyDynamicArray<int>();

        for (int i = 0; i < Config.TestSize; i++)
        {
            array.Add(i);
        }

        return array;
    }
}