using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests;

public class TestMyInsertionSort : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyInsertionSort<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyInsertionSort<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyInsertionSort<string>();
    }
}