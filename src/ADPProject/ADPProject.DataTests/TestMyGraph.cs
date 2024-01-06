using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyGraph : BaseTestReadGraphDataset
{
    public override IMyGraph<int> CreateIntGraph()
    {
        return new MyGraph<int>();
    }
}