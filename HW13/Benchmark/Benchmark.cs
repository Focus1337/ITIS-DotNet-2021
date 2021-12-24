using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MaxColumn, MinColumn]
public class MethodsBenchmark
{
    private static readonly Test test = new();
    private static readonly int argument = Random.Shared.Next();

    [Benchmark]
    public void Static() => TestBase.StaticMethod(argument);

    [Benchmark]
    public void General() => test.GeneralMethod(argument);

    [Benchmark]
    public void Virtual() => test.VirtualMethod(argument);

    [Benchmark]
    public void Generic() => test.GenericMethod(argument);

    [Benchmark]
    public void Dynamic() => test.DynamicMethod(argument);

    [Benchmark]
    public void Reflection() => test.ReflectionMethod(argument);
}

internal class TestBase
{
    public string GeneralMethod(int num) => num.ToString();
    public virtual string VirtualMethod(int num) => num.ToString();
    public static string StaticMethod(int num) => num.ToString();
    public string GenericMethod<T>(T num) where T : struct => num.ToString()!;
    public string DynamicMethod(dynamic num) => num.ToString();
    public string ReflectionMethod(int num) =>
        (typeof(TestBase).GetMethod("StaticMethod")!.Invoke(default, new[] {(object) num}) as string)!;
}

internal class Test : TestBase { }