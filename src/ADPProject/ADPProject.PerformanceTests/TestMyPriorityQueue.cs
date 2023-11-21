using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyPriorityQueue
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyPriorityQueue(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Insert()
    {
        IMyPriorityQueue<int> priorityQueue = new MyPriorityQueue<int>();

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            priorityQueue.Insert(i * 2, i * 3);
        }
        
        benchmarker.Stop();
    }

    [Fact]
    public void FindMin()
    {
        IMyPriorityQueue<int> priorityQueue = GetPriorityQueue(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            priorityQueue.FindMin();
        }
        
        benchmarker.Stop();
    }
    
    [Fact]
    public void DeleteMin()
    {
        IMyPriorityQueue<int> priorityQueue = GetPriorityQueue(Config.DeleteCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            _ = priorityQueue.DeleteMin();
        }
        
        benchmarker.Stop();
    }

    private IMyPriorityQueue<int> GetPriorityQueue(int size)
    {
        IMyPriorityQueue<int> priorityQueue = new MyPriorityQueue<int>();
        
        for (int i = 0; i < size; i++)
        {
            priorityQueue.Insert(i * 2, i * 3);
        }

        return priorityQueue;
    }
}