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
        
        for (int i = 0; i < GeneralTestConfig.AddCount; i++)
        {
            int value = i * 9 * 127;
            string key = value.ToString();
            hashTable.Add(key, value);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.AddCount, hashTable.Size);
    }
    
    [Fact]
    public void Get()
    {
        IMyHashTable<int> hashTable = new MyHashTable<int>();
        
        for (int i = 0; i < GeneralTestConfig.GetCount; i++)
        {
            int value = i * 9 * 127;
            string key = value.ToString();
            hashTable.Add(key, value);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.GetCount; i++)
        {
            int value = i * 9 * 127;
            string key = value.ToString();
            hashTable.GetValuesForKey(key);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(GeneralTestConfig.GetCount, hashTable.Size);
    }

    [Fact]
    public void Remove()
    {
        IMyHashTable<int> hashTable = new MyHashTable<int>();
        
        for (int i = 0; i < GeneralTestConfig.DeleteCount; i++)
        {
            int value = i * 9 * 127;
            string key = value.ToString();
            hashTable.Add(key, value);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < GeneralTestConfig.DeleteCount; i++)
        {
            int value = i * 9 * 127;
            string key = value.ToString();
            hashTable.Remove(key, value);
        }
        
        benchmarker.Stop();
        
        Assert.Equal(0, hashTable.Size);
    }
}