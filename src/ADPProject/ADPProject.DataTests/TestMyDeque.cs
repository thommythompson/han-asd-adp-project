using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyDeque : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyDeque<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyDeque<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyDeque<string>();
    }
}