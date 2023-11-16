using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDoublyLinkedList
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyDoublyLinkedList(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyList<int> list = GetList();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.TestSize; i++)
        {
            list.Add(i);
        }
        
        benchmarker.Stop();
    }

    [Fact]
    public void Get()
    {
        IMyList<int> list = GetList();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        _ = list.Get(Config.GetIndex);
        
        benchmarker.Stop();
    }

    [Fact]
    public void Set()
    {
        IMyList<int> list = GetList();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        list.Set(Config.SetIndex, Config.SetValue);
        
        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByIndex()
    {
        IMyList<int> list = GetList();

        var benchmarker = new Benchmarker(_outputHelper);

        list.RemoveByIndex(Config.RemoveIndex);

        benchmarker.Stop();
    }

    [Fact]
    public void RemoveByValue()
    {
        IMyList<int> list = GetList();

        var benchmarker = new Benchmarker(_outputHelper);

        list.RemoveByValue(Config.RemoveValue);

        benchmarker.Stop();
    }

    private IMyList<int> GetList()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();

        for (int i = 0; i < Config.TestSize; i++)
        {
            list.Add(i);
        }

        return list;
    }
}