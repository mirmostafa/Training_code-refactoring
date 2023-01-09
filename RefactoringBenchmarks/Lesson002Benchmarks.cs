using BenchmarkDotNet.Attributes;

namespace RefactoringBenchmarks;

[MemoryDiagnoser(false)]
public class Lesson002Benchmarks
{
    [Params(40, 4_000)]
    public int Count { get; set; }

    [Benchmark]
    public void FindEvens_Obey1Test()
    {
        var numbers = Enumerable.Range(1, Count);
        var math = new Session001.Lesson02.Math();
        _ = math.FindEvens_Obey1(numbers, false).ToList();
        _ = math.FindEvens_Obey1(numbers, true).ToList();
    }

    [Benchmark]
    public void FindEvens_Obey2Test()
    {
        var numbers = Enumerable.Range(1, Count);
        var math = new Session001.Lesson02.Math();
        _ = math.FindEvens_Obey2(numbers, false).ToList();
        _ = math.FindEvens_Obey2(numbers, true).ToList();
    }
}