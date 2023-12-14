using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDynamicArray : IMyListBaseTest
{
    public TestMyDynamicArray(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMyList<T> GetMyList<T>()
    {
        return new MyDynamicArray<T>();
    }
}