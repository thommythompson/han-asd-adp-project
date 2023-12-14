using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyQuickSort : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyQuickSort<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyQuickSort<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyQuickSort<string>();
    }
}