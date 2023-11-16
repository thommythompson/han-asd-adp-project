using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyDynamicArray
{
    [Fact]
    public void Add()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        
        Assert.Equal(1, array.Length);
        Assert.True(array.Contains(1));
    }

    [Fact]
    public void Get()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        array.Add(2);

        var result = array.Get(1);
        
        Assert.Equal(2, result);
    }

    [Fact]
    public void Set()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        array.Add(2);
        
        array.Set(1, 3);
        
        var result = array.Get(1);
        
        Assert.Equal(3, result);
    }

    [Fact]
    public void RemoveByIndex()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        array.Add(2);
        array.Add(3);
        array.Add(4);
        
        Assert.Equal(4, array.Length);
        Assert.True(array.Contains(3));
        
        array.RemoveByIndex(2);
        
        Assert.Equal(3, array.Length);
        Assert.False(array.Contains(3));
    }
    
    [Fact]
    public void RemoveByValue()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        array.Add(2);
        array.Add(3);
        array.Add(4);
        array.Add(4);
        array.Add(4);
        
        Assert.Equal(6, array.Length);
        Assert.True(array.Contains(4));
        
        array.RemoveByValue(4);
        
        Assert.Equal(5, array.Length);
        Assert.True(array.Contains(4));
    }
}