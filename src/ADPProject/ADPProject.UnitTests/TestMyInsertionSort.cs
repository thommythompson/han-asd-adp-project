using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyInsertionSort
{
    [Fact]
    void Get()
    {
        IMySortedList<int> list = new MyInsertionSort<int>(GetList());

        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(2));
        Assert.Equal(50, list.Get(5));
    }


    private IMyList<int> GetList()
    {
        IMyList<int> list = new MyDoublyLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(10);
        list.Add(20);
        list.Add(3);
        list.Add(50);

        return list;
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
        
        IMySortedList<PizzaOrder> sortedList = new MyInsertionSort<PizzaOrder>(list);

        var result = sortedList.IndexOf(order2);
        
        Assert.Equal(1, result);
    }
}