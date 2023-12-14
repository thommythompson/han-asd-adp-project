using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests.BaseTests;

public abstract class IMyListBaseTests
{
    [Fact]
    public void Add()
    {
        IMyList<int> list = GetMyList<int>();
        
        list.Add(1);
        
        Assert.Equal(1, list.Length);
        Assert.True(list.Contains(1));
    }

    [Fact]
    public void Get()
    {
        IMyList<int> list = GetMyList<int>();
        
        list.Add(1);
        list.Add(2);

        var result = list.Get(1);
        
        Assert.Equal(2, result);
    }

    [Fact]
    public void Set()
    {
        IMyList<int> list = GetMyList<int>();
        
        list.Add(1);
        list.Add(2);
        
        list.Set(1, 3);
        
        var result = list.Get(1);
        
        Assert.Equal(3, result);
    }

    [Fact]
    public void RemoveByIndex()
    {
        IMyList<int> list = GetMyList<int>();
        
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
        IMyList<int> list = GetMyList<int>();
        
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
    
    [Fact]
    public void IndexOf()
    {
        IMyList<int> list = GetMyList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(4);
        list.Add(4);
        
        Assert.Equal(6, list.Length);
        Assert.Equal(3, list.IndexOf(4));
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

        IMyList<Pizza> list = GetMyList<Pizza>();
        
        list.Add(pizza1);
        list.Add(pizza2);
        
        var pizza3 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        Assert.True(list.Contains(pizza3));
        Assert.Equal(1, list.IndexOf(pizza3));
    }
    
    [Fact]
    public void ThePizzaOrderTest()
    {
        var pizza = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var order1 = new PizzaOrder()
        {
            OrderNo = 1,
            Pizza = pizza
        };
        
        var order2 = new PizzaOrder()
        {
            OrderNo = 2,
            Pizza = pizza
        }; 
        
        var order3 = new PizzaOrder()
        {
            OrderNo = 3,
            Pizza = pizza
        };
        
        var order4 = new PizzaOrder()
        {
            OrderNo = 4,
            Pizza = pizza
        };
        
        IMyList<PizzaOrder> list = new MyDynamicArray<PizzaOrder>();
        
        list.Add(order1);
        list.Add(order2);
        list.Add(order3);
        list.Add(order4);

        Assert.Equal(4, list.Length);
        Assert.True(list.Contains(order1));
        Assert.True(list.Contains(order2));
        Assert.True(list.Contains(order3));
        Assert.True(list.Contains(order4));
    }

    public abstract IMyList<T> GetMyList<T>() where T : IComparable<T>;
}