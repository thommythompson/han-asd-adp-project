namespace ADPProject.PerformanceTests.Configuration;

public static class Config
{
    public static readonly int TestSize = 90000000;
    public static readonly int SetIndex = TestSize / 2;
    public static readonly int SetValue = TestSize * 2;
    public static readonly int GetIndex = TestSize / 2;
    public static readonly int RemoveIndex = TestSize / 2;
    public static readonly int RemoveValue = TestSize / 2;
}