using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyPriorityQueue : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyPriorityQueue<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyPriorityQueue<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyPriorityQueue<string>();
    }
}