using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyAVLSearchTree : BaseTestReadSortingDataset
{
    public override IConvertableFromArray<int> CreateIntAdp()
    {
        return new MyAVLSearchTree<int>();
    }

    public override IConvertableFromArray<float> CreateFloatAdp()
    {
        return new MyAVLSearchTree<float>();
    }

    public override IConvertableFromArray<string> CreateStringAdp()
    {
        return new MyAVLSearchTree<string>();
    }
}