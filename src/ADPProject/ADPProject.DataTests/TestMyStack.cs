using ADPProject.DataTests.Extensions;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyStack
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyStack()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMyStack<int> myIntList = new MyStack<int>();

        myIntList.ConvertFromArray(_dataset.LijstAflopend2);
        
        var lastIndex = _dataset.LijstAflopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstAflopend2[lastIndex], myIntList.Top());
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMyStack<int> myStack = new MyStack<int>();
        
        myStack.ConvertFromArray(_dataset.LijstOplopend2);
        
        var lastIndex = _dataset.LijstOplopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstOplopend2[lastIndex], myStack.Top());
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMyStack<float> myStack = new MyStack<float>();
        
        myStack.ConvertFromArray(_dataset.LijstFloat8001);
        
        var lastIndex = _dataset.LijstFloat8001.Length - 1;
        
        Assert.Equal(_dataset.LijstFloat8001[lastIndex], myStack.Top());
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMyStack<float> myStack = new MyStack<float>();
        
        myStack.ConvertFromArray(_dataset.LijstWillekeurig);
        
        var lastIndex = _dataset.LijstWillekeurig.Length - 1;
        
        Assert.Equal(_dataset.LijstWillekeurig[lastIndex], myStack.Top());
    }
}