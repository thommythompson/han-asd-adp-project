using ADPProject.Library.Interfaces;
using ADPProject.PerformanceTests.BaseTests;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests;

public class TestMyDoublyLinkedList : IMyListBaseTest
{
    public TestMyDoublyLinkedList(ITestOutputHelper outputHelper) : base(outputHelper)
    {
    }

    public override IMyList<T> GetMyList<T>()
    {
        return new MyDoublyLinkedList<T>();
    }
}