using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMySelectionSort : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MySelectionSort<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MySelectionSort<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MySelectionSort<string>();
    }
}