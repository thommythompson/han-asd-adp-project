using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyPriorityQueue
{
    [Fact]
    void Insert()
    {
        IMyPriorityQueue<int> priorityQueue = new MyPriorityQueue<int>();
        
        priorityQueue.Insert(1, 2);
        priorityQueue.Insert(2, 3);
        priorityQueue.Insert(10, 90);
        priorityQueue.Insert(11, 70);
        priorityQueue.Insert(101, 2);
        priorityQueue.Insert(2, 9);
        priorityQueue.Insert(99, 9);
    }

    [Fact]
    void FindMin()
    {
        IMyPriorityQueue<int> priorityQueue = GetPriorityQueue();
        
        var result = priorityQueue.FindMin();
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    void DeleteMin()
    {
        IMyPriorityQueue<int> priorityQueue = GetPriorityQueue();
        
        _ = priorityQueue.DeleteMin();
        _ = priorityQueue.DeleteMin();
        _ = priorityQueue.DeleteMin();
        
        var result1 = priorityQueue.DeleteMin();
        
        Assert.Equal(90, result1);
        
        _ = priorityQueue.DeleteMin();
        _ = priorityQueue.DeleteMin();
        
        var result2 = priorityQueue.DeleteMin();
        
        Assert.Equal(2, result2);
    }
    
    private IMyPriorityQueue<int> GetPriorityQueue()
    {
        IMyPriorityQueue<int> priorityQueue = new MyPriorityQueue<int>();
        
        priorityQueue.Insert(1, 2);
        priorityQueue.Insert(2, 3);
        priorityQueue.Insert(10, 90);
        priorityQueue.Insert(11, 70);
        priorityQueue.Insert(101, 2);
        priorityQueue.Insert(2, 9);
        priorityQueue.Insert(99, 9);

        return priorityQueue;
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
        
        IMyPriorityQueue<Pizza> priorityQueue = new MyPriorityQueue<Pizza>();
        
        priorityQueue.Insert(1, pizza1);
        priorityQueue.Insert(2, pizza2);
        
        Assert.Equal(pizza1, priorityQueue.DeleteMin());
    }
}