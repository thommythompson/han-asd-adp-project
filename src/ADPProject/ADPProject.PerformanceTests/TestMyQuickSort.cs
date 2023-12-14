using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyQuickSort : IMySortedListBaseTest
{
    public TestMyQuickSort(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MyQuickSort<T>();
    }
}