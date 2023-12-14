using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests.BaseTests;

public abstract class IMySortedListBaseTest
{
    [Fact]
    void Get()
    {
        IMyList<int> list = new MyDynamicArray<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(10);
        list.Add(20);
        list.Add(3);
        list.Add(50);
        
        IMySortedList<int> sortedList = GetMySortedList(list);

        Assert.Equal(1, sortedList.Get(0));
        Assert.Equal(3, sortedList.Get(2));
        Assert.Equal(50, sortedList.Get(5));
    }
    
    [Fact]
    public void ThePizzaTest()
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
        
        IMySortedList<PizzaOrder> sortedList = GetMySortedList(list);
        
        var result = sortedList.IndexOf(order2);
        
        Assert.Equal(1, result);
    }

    public abstract IMySortedList<T> GetMySortedList<T>(IMyList<T> list) where T : IComparable<T>;
}