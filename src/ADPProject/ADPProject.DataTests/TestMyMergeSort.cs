using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyMergeSort : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyMergeSort<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyMergeSort<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyMergeSort<string>();
    }
}