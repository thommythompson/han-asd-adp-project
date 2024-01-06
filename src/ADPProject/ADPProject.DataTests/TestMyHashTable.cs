using ADPProject.DataTests.BaseTests;
using ADPProject.Library.Interfaces;

namespace ADPProject.DataTests;

public class TestMyHashTable : BaseTestReadHashingDataset
{
    protected override IMyHashTable<int> CreateIntHashTable()
    {
        return new MyHashTable<int>();
    }
}