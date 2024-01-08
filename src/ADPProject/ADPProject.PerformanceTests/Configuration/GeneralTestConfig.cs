namespace ADPProject.PerformanceTests.Configuration;

public static class GeneralTestConfig
{
    public static readonly int AddCount = 1000000; // Amount of items to add during benchmarks tests
    public static readonly int GetCount = 10000; // Amount of get operations to execute during benchmark tests
    public static readonly int SetCount = 10000; // Amount of set operations to execute during benchmark tests
    public static readonly int DeleteCount = 10000; // Amount of delete operations to execute during benchmark tests
    public static readonly int MiscCount = 1000; // Amount of times to execute a miscellaneous operation during benchmarks tests
}