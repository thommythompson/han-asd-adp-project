using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyInsertionSort
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyInsertionSort()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMySortedList<int> myList = new MyInsertionSort<int>();

        myList.ConvertFromArray(_dataset.LijstAflopend2);
        
        var lastIndex = _dataset.LijstAflopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstAflopend2[0], myList.Get(0));
        Assert.Equal(_dataset.LijstAflopend2[lastIndex], myList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMySortedList<int> myList = new MyInsertionSort<int>();
        
        myList.ConvertFromArray(_dataset.LijstOplopend2);
        
        var lastIndex = _dataset.LijstOplopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstOplopend2[0], myList.Get(0));
        Assert.Equal(_dataset.LijstOplopend2[lastIndex], myList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMySortedList<float> myList = new MyInsertionSort<float>();
        
        myList.ConvertFromArray(_dataset.LijstFloat8001);
        
        var lastIndex = _dataset.LijstFloat8001.Length - 1;
        
        Assert.Equal(_dataset.LijstFloat8001[0], myList.Get(0));
        Assert.Equal(_dataset.LijstFloat8001[lastIndex], myList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMySortedList<float> myList = new MyInsertionSort<float>();
        
        myList.ConvertFromArray(_dataset.LijstWillekeurig);
        
        var lastIndex = _dataset.LijstWillekeurig.Length - 1;
        
        Assert.Equal(_dataset.LijstWillekeurig[0], myList.Get(0));
        Assert.Equal(_dataset.LijstWillekeurig[lastIndex], myList.Get(lastIndex));
    }
}