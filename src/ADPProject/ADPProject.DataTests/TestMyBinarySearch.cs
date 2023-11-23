using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyBinarySearch : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyBinarySearch<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyBinarySearch<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyBinarySearch<string>();
    }
}