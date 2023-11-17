using ADPProject.DataTests.Extensions;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyDynamicArray
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyDynamicArray()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMyList<int> myIntList = new MyDynamicArray<int>();

        myIntList.ConvertFromArray(_dataset.LijstAflopend2);
        
        var lastIndex = _dataset.LijstAflopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstAflopend2[0], myIntList.Get(0));
        Assert.Equal(_dataset.LijstAflopend2[lastIndex], myIntList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMyList<int> myIntList = new MyDynamicArray<int>();
        
        myIntList.ConvertFromArray(_dataset.LijstOplopend2);
        
        var lastIndex = _dataset.LijstOplopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstOplopend2[0], myIntList.Get(0));
        Assert.Equal(_dataset.LijstOplopend2[lastIndex], myIntList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMyList<float> myFloatList = new MyDynamicArray<float>();
        
        myFloatList.ConvertFromArray(_dataset.LijstFloat8001);
        
        var lastIndex = _dataset.LijstFloat8001.Length - 1;
        
        Assert.Equal(_dataset.LijstFloat8001[0], myFloatList.Get(0));
        Assert.Equal(_dataset.LijstFloat8001[lastIndex], myFloatList.Get(lastIndex));
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMyList<float> myFloatList = new MyDynamicArray<float>();
        
        myFloatList.ConvertFromArray(_dataset.LijstWillekeurig);
        
        var lastIndex = _dataset.LijstWillekeurig.Length - 1;
        
        Assert.Equal(_dataset.LijstWillekeurig[0], myFloatList.Get(0));
        Assert.Equal(_dataset.LijstWillekeurig[lastIndex], myFloatList.Get(lastIndex));

    }
}