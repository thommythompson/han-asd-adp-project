using ADPProject.DataTests.Extensions;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyDeque
{
    private SortingDataset _dataset { get; init; } 
    
    public TestMyDeque()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        IMyDeque<int> myDeque = new MyDeque<int>();

        myDeque.ConvertFromArray(_dataset.LijstAflopend2);
        
        var lastIndex = _dataset.LijstAflopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstAflopend2[0], myDeque.DeleteLeft());
        Assert.Equal(_dataset.LijstAflopend2[lastIndex], myDeque.DeleteRight());
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        IMyDeque<int> myDeque = new MyDeque<int>();
        
        myDeque.ConvertFromArray(_dataset.LijstOplopend2);
        
        var lastIndex = _dataset.LijstOplopend2.Length - 1;
        
        Assert.Equal(_dataset.LijstOplopend2[0], myDeque.DeleteLeft());
        Assert.Equal(_dataset.LijstOplopend2[lastIndex], myDeque.DeleteRight());
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        IMyDeque<float> myDeque = new MyDeque<float>();
        
        myDeque.ConvertFromArray(_dataset.LijstFloat8001);
        
        var lastIndex = _dataset.LijstFloat8001.Length - 1;
        
        Assert.Equal(_dataset.LijstFloat8001[0], myDeque.DeleteLeft());
        Assert.Equal(_dataset.LijstFloat8001[lastIndex], myDeque.DeleteRight());
    }
    
    [Fact]
    public void CanReadLijstWillekeurig()
    {
        IMyDeque<float> myDeque = new MyDeque<float>();
        
        myDeque.ConvertFromArray(_dataset.LijstWillekeurig);
        
        var lastIndex = _dataset.LijstWillekeurig.Length - 1;
        
        Assert.Equal(_dataset.LijstWillekeurig[0], myDeque.DeleteLeft());
        Assert.Equal(_dataset.LijstWillekeurig[lastIndex], myDeque.DeleteRight());
    }
}