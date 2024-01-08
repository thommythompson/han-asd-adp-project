using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.Configuration;
using ADPProject.PerformanceTests.Helpers;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyBinarySearch
{
    private ITestOutputHelper _outputHelper { get; init; }
    
    public TestMyBinarySearch(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Search()
    {
        IMySortedList<int> list = GetInsertionSort(GeneralTestConfig.AddCount);

        IMyBinarySearch<int> binarySearch = new MyBinarySearch<int>(list);
        
        var benchmarker = new Benchmarker(_outputHelper);

        binarySearch.Search(GeneralTestConfig.AddCount - 1);
        
        benchmarker.Stop();
    }

    private IMySortedList<int> GetInsertionSort(int size)
    {
        IMyList<int> list = new MyDynamicArray<int>();

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        return new MyInsertionSort<int>(list);
    }
}