using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Dedge;
using Tests;

namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Cardidy.Identify("4127540509730813").Single());


        var summary = BenchmarkRunner.Run<BenchmarkCardidy>();
        
        Console.WriteLine(summary);
    }
}
