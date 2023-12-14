using ADPProject.Library.Interfaces;
using ADPProject.Tests.BaseTests;

namespace ADPProject.Tests;

public class TestMyDoublyLinkedList : IMyListBaseTests
{
    public override IMyList<T> GetMyList<T>()
    {
        return new MyDoublyLinkedList<T>();
    }
}