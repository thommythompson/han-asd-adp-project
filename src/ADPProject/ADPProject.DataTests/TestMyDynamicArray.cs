using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyDynamicArray : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyDynamicArray<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyDynamicArray<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyDynamicArray<string>();
    }
}