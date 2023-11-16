using ADPProject.Library.Interfaces;

namespace ADPProject.Tests;

public class TestMyDoublyLinkedList
{
    [Fact]
    public void Add()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        
        Assert.Equal(1, list.Length);
        Assert.True(list.Contains(1));
    }

    [Fact]
    public void Get()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);

        var result = list.Get(1);
        
        Assert.Equal(2, result);
    }

    [Fact]
    public void Set()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        
        list.Set(1, 3);
        
        var result = list.Get(1);
        
        Assert.Equal(3, result);
    }

    [Fact]
    public void RemoveByIndex()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        
        Assert.Equal(4, list.Length);
        Assert.True(list.Contains(3));
        
        list.RemoveByIndex(2);
        
        Assert.Equal(3, list.Length);
        Assert.False(list.Contains(3));
    }
    
    [Fact]
    public void RemoveByValue()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(4);
        list.Add(4);
        
        Assert.Equal(6, list.Length);
        Assert.True(list.Contains(4));
        
        list.RemoveByValue(4);
        
        Assert.Equal(5, list.Length);
        Assert.True(list.Contains(4));
    }
}