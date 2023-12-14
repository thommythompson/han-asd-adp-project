using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyMergeSort : IMySortedListBaseTest
{
    public TestMyMergeSort(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MyMergeSort<T>();
    }
}