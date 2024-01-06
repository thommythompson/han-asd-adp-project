using ADPProject.Library.Interfaces;
using ADPProject.Tests.CustomTypes;

namespace ADPProject.Tests;

public class TestMyHashTable
{
    [Fact]
    void Add()
    {
        IMyHashTable<Pizza> hashTable = new MyHashTable<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        hashTable.Add(pizza1.Name, pizza1);
        Assert.Equal(1, hashTable.Size);
        hashTable.Add(pizza2.Name, pizza2);
        Assert.Equal(2, hashTable.Size);
        hashTable.Add(pizza3.Name, pizza3);
        Assert.Equal(3, hashTable.Size);
    }
    
    [Fact]
    void Get()
    {
        IMyHashTable<Pizza> hashTable = new MyHashTable<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        hashTable.Add(pizza1.Name, pizza1);
        hashTable.Add(pizza2.Name, pizza2);
        hashTable.Add(pizza3.Name, pizza3);

        Assert.Equal(pizza1, hashTable.GetValuesForKey(pizza1.Name).First());
        Assert.Equal(pizza2, hashTable.GetValuesForKey(pizza2.Name).First());
        Assert.Equal(pizza3, hashTable.GetValuesForKey(pizza3.Name).First());
    }
    
    [Fact]
    void Remove()
    {
        IMyHashTable<Pizza> hashTable = new MyHashTable<Pizza>();

        var pizza1 = new Pizza()
        {
            Name = "Margherita",
            NumberOfSlices = 8
        };
        
        var pizza2 = new Pizza()
        {
            Name = "Bufalina",
            NumberOfSlices = 8
        };

        var pizza3 = new Pizza()
        {
            Name = "Quattro Stagioni",
            NumberOfSlices = 8
        };
        
        hashTable.Add(pizza1.Name, pizza1);
        hashTable.Add(pizza2.Name, pizza2);
        hashTable.Add(pizza3.Name, pizza3);

        hashTable.Remove(pizza1.Name, pizza1);
        Assert.Equal(2, hashTable.Size);
        hashTable.Remove(pizza1.Name, pizza2);
        Assert.Equal(2, hashTable.Size);
        hashTable.Remove(pizza2.Name, pizza2);
        Assert.Equal(1, hashTable.Size);
        hashTable.Remove(pizza2.Name, pizza2);
        Assert.Equal(1, hashTable.Size);
        hashTable.Remove(pizza3.Name, pizza3);
        Assert.Equal(0, hashTable.Size);
    }
}