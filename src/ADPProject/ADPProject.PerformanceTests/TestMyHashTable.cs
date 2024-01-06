using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyHashTable
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyHashTable(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyHashTable<int> hashTable = new MyHashTable<int>();
        
        var benchmarker = new Benchmarker(_outputHelper);

        int value;
        for (int i = 0; i < Config.AddCount; i++)
        {
            value = + 1 * 100;
            hashTable.Add(value.ToString(), value);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.AddCount, hashTable.Size);
    }
    
    [Fact]
    public void Get()
    {
        IMyHashTable<int> hashTable = new MyHashTable<int>();
        
        int value;
        for (int i = 0; i < Config.AddCount; i++)
        {
            value = + 1 * 100;
            hashTable.Add(value.ToString(), value);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);

        int key;
        for (int i = 0; i < Config.AddCount; i++)
        {
            key = + 1 * 100;
            hashTable.GetValuesForKey(key.ToString());
        }
        
        benchmarker.Stop();
        
        Assert.Equal(Config.GetCount, hashTable.Size);
    }

    [Fact]
    public void Remove()
    {
        IMyHashTable<int> hashTable = new MyHashTable<int>();

        string key;
        int value;
        for (int i = 0; i < Config.AddCount; i++)
        {
            value = + 1 * 100;
            key = value.ToString();
            hashTable.Add(key, value);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.AddCount; i++)
        {
            value = + 1 * 100;
            key = value.ToString();
            hashTable.Remove(key, value);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, hashTable.Size);
    }
}