using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyDeque
{
    [Fact]
    public void InsertLeft()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        deque.InsertLeft(3);
        deque.InsertLeft(2);
        deque.InsertLeft(1);
        
        Assert.Equal(3, deque.Size);
    }

    [Fact]
    public void InsertRight()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        deque.InsertRight(1);
        deque.InsertRight(2);
        deque.InsertRight(3);
        
        Assert.Equal(3, deque.Size);
    }
    
    [Fact]
    public void DeleteLeft()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        deque.InsertRight(1);
        deque.InsertRight(2);
        deque.InsertRight(3);

        var result1 = deque.DeleteLeft();
        
        Assert.Equal(2, deque.Size);
        Assert.Equal(1, result1);
        
        deque.InsertLeft(7);
        
        var result2 = deque.DeleteLeft();
        
        Assert.Equal(2, deque.Size);
        Assert.Equal(7, result2);
    }
    
    [Fact]
    public void DeleteRight()
    {
        IMyDeque<int> deque = new MyDeque<int>();
        
        deque.InsertRight(7);
        deque.InsertRight(2);
        deque.InsertRight(3);
        deque.InsertLeft(1);

        var result = deque.DeleteRight();
        
        Assert.Equal(3, deque.Size);
        Assert.Equal(3, result);
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
        
        IMyDeque<Pizza> deque = new MyDeque<Pizza>();
        
        deque.InsertRight(pizza1);
        deque.InsertRight(pizza2);
        
        Assert.Equal(pizza2, deque.DeleteRight());
    }
}