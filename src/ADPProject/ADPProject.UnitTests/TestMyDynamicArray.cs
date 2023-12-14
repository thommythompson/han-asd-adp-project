using ADPProject.Library.Interfaces;
using ADPProject.Tests.BaseTests;

namespace ADPProject.Tests;

public class TestMyDynamicArray : IMyListBaseTests
{
    public override IMyList<T> GetMyList<T>()
    {
        return new MyDynamicArray<T>();
    }
}