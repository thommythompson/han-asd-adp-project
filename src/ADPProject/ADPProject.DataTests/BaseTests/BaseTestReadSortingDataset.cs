using ADPProject.DataTests.Helpers;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests.BaseTests;

public abstract class BaseTestReadSortingDataset
{
    private SortingDataset? _dataset { get; init; } 
    
    public BaseTestReadSortingDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetSortingDataset();
        }
    }
    
    [Fact]
    public void CanReadLijstAflopend2()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstAflopend2);
    }
    
    [Fact]
    public void CanReadLijstOplopend2()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstOplopend2);
    }
    
    [Fact]
    public void CanReadLijstFloat8001()
    {
        var adp = CreateFloatAdp();
        
        adp.ConvertFromArray(_dataset.LijstFloat8001);
    }
    
    [Fact]
    public void CanReadLijstGesorteerdAflopend3()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstGesorteerdAflopend3);
    }
    
    [Fact]
    public void CanReadLijstGesorteerdOplopend3()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstGesorteerdOplopend3);
    }
    
    [Fact]
    public void CanReadLijstHerhaald1000()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstHerhaald1000);
    }
    
    [Fact]
    public void CanReadLijstLeeg0()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstLeeg0);
    }
    
    [Fact]
    public void CanReadLijstNull1()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstNull1);
    }
    
    [Fact]
    public void CanReadLijstNull3()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstNull3);
    }
    
    [Fact]
    public void CanReadLijstOnsorteerbaar3()
    {
        var adp = CreateStringAdp();
        
        adp.ConvertFromArray(_dataset.LijstOnsorteerbaar3);
    }
    
    [Fact]
    public void CanReadLijstOplopend10000()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstOplopend10000);
    }
    
    [Fact]
    public void CanReadLijstWillekeurig10000()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstWillekeurig10000);
    }
    
    [Fact]
    public void CanReadLijstWillekeurig3()
    {
        var adp = CreateIntAdp();
        
        adp.ConvertFromArray(_dataset.LijstWillekeurig3);
    }
    
    public abstract IConvertableFromArray<int> CreateIntAdp();
    public abstract IConvertableFromArray<float> CreateFloatAdp();
    public abstract IConvertableFromArray<string> CreateStringAdp();
}