using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyAVLSearchTree
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyAVLSearchTree(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Insert()
    {
        var avl = new MyAVLSearchTree<int>();

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            avl.Insert(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.AddCount, avl.InOrder().Count);
    }
    
    [Fact]
    public void Remove()
    {
        var avl = new MyAVLSearchTree<int>();
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            avl.Insert(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            avl.Remove(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, avl.InOrder().Count);
    }
    
    [Fact]
    public void Find()
    {
        var avl = new MyAVLSearchTree<int>();
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.Insert(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.Find(i);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.GetCount, avl.InOrder().Count);
    }
    
    [Fact]
    public void FindMin()
    {
        var avl = new MyAVLSearchTree<int>();
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.Insert(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.FindMin();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.GetCount, avl.InOrder().Count);
    }
    
    [Fact]
    public void FindMax()
    {
        var avl = new MyAVLSearchTree<int>();
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.Insert(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            avl.FindMax();
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.GetCount, avl.InOrder().Count);
    }
}