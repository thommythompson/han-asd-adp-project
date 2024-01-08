namespace ADPProject.PerformanceTests.Configuration;

public class SortedListTestConfig
{
    public static readonly int AddCount = 10000; // Amount of items to add during benchmarks tests
    public static readonly int GetCount = 1000; // Amount of get operations to execute during benchmark tests
    public static readonly int SetCount = 1000; // Amount of set operations to execute during benchmark tests
    public static readonly int DeleteCount = 1000; // Amount of delete operations to execute during benchmark tests
}