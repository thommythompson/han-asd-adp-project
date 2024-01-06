using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMySelectionSort : IMySortedListBaseTest
{
    public TestMySelectionSort(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MySelectionSort<T>(list);
    }
}