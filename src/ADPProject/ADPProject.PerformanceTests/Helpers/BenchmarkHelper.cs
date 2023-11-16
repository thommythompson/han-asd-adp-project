using System.Diagnostics;
using Xunit.Abstractions;

namespace ADPProject.PerformanceTests.Helpers;

public class Benchmarker
{
    private ITestOutputHelper _outputHelper { get; init; }
    private Stopwatch _stopwatch { get; init; }
    
    public Benchmarker(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _stopwatch = new Stopwatch();
        Start();
    }

    private void Start()
    {
        _outputHelper.WriteLine("Starting timer");
        _stopwatch.Start();
    }

    public void Stop()
    {
        _stopwatch.Stop();
        _outputHelper.WriteLine($"Test method took {_stopwatch.ElapsedMilliseconds} ms");
    }
}