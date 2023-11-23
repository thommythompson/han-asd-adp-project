using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyBinarySearch
{
    [Fact]
    public void Search()
    {
        IMyList<int> list = new MyDynamicArray<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(6);
        list.Add(7);
        list.Add(8);
        list.Add(4);
        list.Add(5);
        list.Add(9);
        list.Add(10);

        IMySortedList<int> sortedList = new MyInsertionSort<int>(list);

        IMyBinarySearch<int> binarySearch = new MyBinarySearch<int>(sortedList);

        var result = binarySearch.Search(5);
        
        Assert.Equal(4, result);
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
        
        IMyBinarySearch<PizzaOrder> binarySearch = new MyBinarySearch<PizzaOrder>(sortedList);

        var result = binarySearch.Search(order2);
        
        Assert.Equal(1, result);
    }
}