using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyStack
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyStack(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Push()
    {
        IMyStack<int> stack = new MyStack<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.AddCount; i++)
        {
            stack.Push(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.AddCount, stack.Size);
    }
    
    [Fact]
    public void Pop()
    {
        IMyStack<int> stack = GetStack(GeneralTestConfig.DeleteCount);
        
        var benchmarker = new Benchmarker(_outputHelper);

        for (int i = 0; i < GeneralTestConfig.DeleteCount; i++)
        {
            stack.Pop();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, stack.Size);
    }
    
    [Fact]
    public void Top()
    {
        IMyStack<int> stack = GetStack(GeneralTestConfig.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.GetCount; i++)
        {
            stack.Top();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.GetCount, stack.Size);
    }

    public IMyStack<int> GetStack(int size)
    {
        IMyStack<int> stack = new MyStack<int>();
        
        for (int i = 0; i < size; i++)
        {
            stack.Push(i);
        }

        return stack;
    }
}