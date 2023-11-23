using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

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
    
    [Fact]
    public void IndexOf()
    {
        IMyList<int> array = new MyDynamicArray<int>();
        
        array.Add(1);
        array.Add(2);
        array.Add(3);
        array.Add(4);
        array.Add(4);
        array.Add(4);
        
        Assert.Equal(6, array.Length);
        Assert.Equal(3, array.IndexOf(4));
    }
    
    
    [Fact]
    public void ThePizzaTest()
    {
        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        IMyList<Pizza> array = new MyDynamicArray<Pizza>();
        
        array.Add(pizza1);
        array.Add(pizza2);
        
        var pizza3 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        Assert.True(array.Contains(pizza3));
        Assert.Equal(1, array.IndexOf(pizza3));
    }
}