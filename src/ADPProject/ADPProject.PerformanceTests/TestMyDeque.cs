using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDeque
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyDeque(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void InsertLeft()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.AddCount; i++)
        {
            deque.InsertLeft(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.AddCount, deque.Size);
    }

    [Fact]
    public void InsertRight()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.AddCount; i++)
        {
            deque.InsertRight(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.AddCount, deque.Size);
    }
    
    [Fact]
    public void DeleteLeft()
    {
        IMyDeque<int> deque = GetDeque(GeneralTestConfig.DeleteCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.DeleteCount; i++)
        {
            _ = deque.DeleteLeft();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, deque.Size);
    }
    
    [Fact]
    public void DeleteRight()
    {
        IMyDeque<int> deque = GetDeque(GeneralTestConfig.DeleteCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.DeleteCount; i++)
        {
            _ = deque.DeleteRight();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, deque.Size);
    }

    public IMyDeque<int> GetDeque(int size)
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        for (int i = 0; i < size; i++)
        {
            deque.InsertLeft(i);
        }

        return deque;
    }
}