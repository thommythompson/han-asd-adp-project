using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyInsertionSort : IMySortedListBaseTest
{
    public TestMyInsertionSort(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MyInsertionSort<T>(list);
    }
}