using App;
using BenchmarkDotNet.Running;
using Dedge;

Console.WriteLine(Cardidy.Identify("4127540509730813").Single());
var summary = BenchmarkRunner.Run<BenchmarkCardidy>();
Console.WriteLine(summary);