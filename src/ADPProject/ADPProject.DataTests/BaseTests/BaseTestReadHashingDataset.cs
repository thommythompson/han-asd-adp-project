using ADPProject.DataTests.Helpers;
using ADPProject.Library.Interfaces;
using ADPProject.Tests.Data;

namespace ADPProject.DataTests.BaseTests;

public abstract class BaseTestReadHashingDataset
{
    private HashingDataset? _dataset { get; init; } 
    
    public BaseTestReadHashingDataset()
    {
        using (var jsonFetcher = new JsonFetcher())
        {
            _dataset = jsonFetcher.GetHashingDataset();
        }
    }
    
    [Fact]
    public void CanReadHashtableSleutelWaardes()
    {
        IMyHashTable<int> hashTable = CreateIntHashTable();

        foreach (var value in _dataset.HashTabelSleutelsWaardes.a)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.a), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.b)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.b), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.c)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.c), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.d)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.d), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.e)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.e), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.f)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.f), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.g)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.g), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.h)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.h), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.i)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.i), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.j)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.j), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.k)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.k), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.l)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.l), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.m)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.m), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.n)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.n), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.o)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.o), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.p)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.p), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.q)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.q), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.r)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.r), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.s)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.s), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.t)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.t), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.u)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.u), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.v)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.v), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.w)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.w), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.x)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.x), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.y)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.y), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.z)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.z), value);
        }
        foreach (var value in _dataset.HashTabelSleutelsWaardes.z0)
        {
            hashTable.Add(nameof(_dataset.HashTabelSleutelsWaardes.z0), value);
        }
    }

    protected abstract IMyHashTable<int> CreateIntHashTable();
}