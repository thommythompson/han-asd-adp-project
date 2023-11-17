using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyStack
{
    [Fact]
    public void Push()
    {
        IMyStack<int> stack = new MyStack<int>();
        
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);
        
        Assert.Equal(4, stack.Size);
    }
    
    [Fact]
    public void Pop()
    {
        IMyStack<int> stack = new MyStack<int>();
        
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);
        stack.Push(1);

        stack.Pop();
        
        Assert.Equal(3, stack.Size);
    }
    
    [Fact]
    public void TopAndPeek()
    {
        IMyStack<int> stack = new MyStack<int>();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        var result = stack.Top();
        
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void IsEmpty()
    {
        IMyStack<int> stack = new MyStack<int>();
        
        Assert.True(stack.IsEmpty());
        
        stack.Push(1);

        Assert.False(stack.IsEmpty());
    }
}