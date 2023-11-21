using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyBinarySearch
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyBinarySearch()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMySortedList<int> myList = new MyInsertionSort<int>().ConvertFromArray(_dataset.LijstAflopend2);

        IMyBinarySearch<int> binarySearch = new MyBinarySearch<int>(myList);

        var lastIndex = _dataset.LijstAflopend2.Length - 1;
        
        var index = binarySearch.Search(myList.Get(lastIndex));
        
        Assert.Equal(lastIndex, index);
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMySortedList<int> myList = new MyInsertionSort<int>().ConvertFromArray(_dataset.LijstOplopend2);

        IMyBinarySearch<int> binarySearch = new MyBinarySearch<int>(myList);

        var lastIndex = _dataset.LijstOplopend2.Length - 1;
        
        var index = binarySearch.Search(myList.Get(lastIndex));
        
        Assert.Equal(lastIndex, index);
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMySortedList<float> myList = new MyInsertionSort<float>().ConvertFromArray(_dataset.LijstFloat8001);

        IMyBinarySearch<float> binarySearch = new MyBinarySearch<float>(myList);
        
        var lastIndex = myList.Length - 1;

        var valueToSearchFor = myList.Get(lastIndex);
        
        var resultIndexOf = myList.IndexOf(valueToSearchFor);
        
        var resultBinarySearch = binarySearch.Search(valueToSearchFor);
        
        Assert.NotEqual(resultIndexOf, resultBinarySearch); // because binary search start in the middle and there are duplicate values
        Assert.Equal(7000, resultBinarySearch);
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMySortedList<float> myList = new MyInsertionSort<float>().ConvertFromArray(_dataset.LijstWillekeurig);
        
        IMyBinarySearch<float> binarySearch = new MyBinarySearch<float>(myList);

        var lastIndex = _dataset.LijstWillekeurig.Length - 1;
        
        var index = binarySearch.Search(myList.Get(lastIndex));
        
        Assert.Equal(lastIndex, index);
    }
}