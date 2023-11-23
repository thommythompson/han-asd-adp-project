using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyDoublyLinkedList : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyDoublyLinkedList<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyDoublyLinkedList<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyDoublyLinkedList<string>();
    }
}