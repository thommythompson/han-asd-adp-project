using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyPriorityQueue
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyPriorityQueue()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMyPriorityQueue<int> myPriorityQueue = new MyPriorityQueue<int>();

        myPriorityQueue.ConvertFromArray(_dataset.LijstAflopend2);
        
        Assert.Equal(_dataset.LijstAflopend2[0], myPriorityQueue.FindMin());
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMyPriorityQueue<int> myPriorityQueue = new MyPriorityQueue<int>();

        myPriorityQueue.ConvertFromArray(_dataset.LijstOplopend2);
        
        Assert.Equal(_dataset.LijstOplopend2[0], myPriorityQueue.FindMin());
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMyPriorityQueue<float> myPriorityQueue = new MyPriorityQueue<float>();

        myPriorityQueue.ConvertFromArray(_dataset.LijstFloat8001);
        
        Assert.Equal(_dataset.LijstFloat8001[0], myPriorityQueue.FindMin());
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMyPriorityQueue<float> myPriorityQueue = new MyPriorityQueue<float>();

        myPriorityQueue.ConvertFromArray(_dataset.LijstWillekeurig);
        
        Assert.Equal(_dataset.LijstWillekeurig[0], myPriorityQueue.FindMin());
    }
}