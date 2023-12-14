using ADPProject.Library.Interfaces;
using ADPProject.Tests.BaseTests;

namespace ADPProject.Tests;

public class TestMySelectionSort : IMySortedListBaseTest
{
    public override IMySortedList<T> GetMySortedList<T>(IMyList<T> list)
    {
        return new MySelectionSort<T>(list);
    }
}