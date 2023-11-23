using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyStack : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyStack<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyStack<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyStack<string>();
    }
}