﻿using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyInsertionSort
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyInsertionSort(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Add()
    {
        IMyList<int> list = new MyDynamicArray<int>(); // Doubly linked list takes ages

        for (int i = 0; i < Config.AddCount; i++)
        {
            list.Add(i);
        }
        
        var benchmarker = new Benchmarker(_outputHelper);

        var mySortedList = new MyInsertionSort<int>(list); 
        
        benchmarker.Stop();
        
        Assert.Equal(Config.AddCount, mySortedList.Length);
    }

    [Fact]
    public void GetAsc()
    {
        IMySortedList<int> list = GetList(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.GetCount; i++)
        {
            _ = list.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void GetDesc()
    {
        IMySortedList<int> list = GetList(Config.GetCount);
        
        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.GetCount - 1; i > 0; i--)
        {
            list.Get(i);
        }

        benchmarker.Stop();
    }
    
    [Fact]
    public void RemoveByIndexZero()
    {
        IMySortedList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            list.RemoveByIndex(0);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByIndexDesc()
    {
        IMySortedList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByIndex(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    [Fact]
    public void RemoveByValueAsc()
    {
        IMySortedList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = 0; i < Config.DeleteCount; i++)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }
    
    [Fact]
    public void RemoveByValueDesc()
    {
        IMySortedList<int> list = GetList(Config.DeleteCount);

        var benchmarker = new Benchmarker(_outputHelper);
        
        for (int i = Config.DeleteCount - 1; i >= 0; i--)
        {
            list.RemoveByValue(i);
        }

        benchmarker.Stop();
        
        Assert.Equal(0, list.Length);
    }

    private IMySortedList<int> GetList(int size)
    {
        IMyList<int> list = new MyDynamicArray<int>(); // Doubly linked list takes ages

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }
        
        IMySortedList<int> mySortedList = new MyInsertionSort<int>(list);

        return mySortedList;
    }
}