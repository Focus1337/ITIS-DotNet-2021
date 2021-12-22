using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Testing;
using WebAppHW12;

namespace Benchmark
{

    [MinColumn, MaxColumn]
    public class Ebenchmark
    {
        private readonly HttpClient _clientCs;
        private readonly HttpClient _clientFs;

        public Ebenchmark()
        {
            _clientCs = new WebApplicationFactory<Startup>().CreateClient();
            _clientFs = new WebApplicationFactory<Startup>().CreateClient();
        }

        //private const string ResponseBody = "https://localhost:5001/calculate?expressionString=2+3";

        // private static async Task Sum(HttpClient client) =>
        //     await client.GetAsync("https://localhost:5001/calculate?expressionString=2+3"); //($"{ResponseBody}");
        //
        // [Benchmark]
        // public async Task SumCs() => await Sum(_clientCs);
        // // await _clientCs.GetAsync($"{ResponseBody}");
        //
        // [Benchmark]
        // public async Task SumFs() => await Sum(_clientFs);
        // //await _clientFs.GetAsync($"{ResponseBody}");
        //
        // private static async Task SomeExpression(HttpClient client) =>
        //     await client.GetAsync("https://localhost:5001/calculate?expressionString=(2+3)/12*7+8*9");
        //
        // [Benchmark]
        // public async Task ExpressionCs() => await SomeExpression(_clientCs);
        //
        // [Benchmark]
        // public async Task ExpressionFs() => await SomeExpression(_clientFs);


        private static void Sum(HttpClient client) =>
            client.GetAsync("https://localhost:5001/calculate?expressionString=2+3"); //($"{ResponseBody}");

        [Benchmark]
        public void SumCs() => Sum(_clientCs);

        [Benchmark]
        public void SumFs() => Sum(_clientFs);

        private static void SomeExpression(HttpClient client) =>
            client.GetAsync("https://localhost:5001/calculate?expressionString=(2+3)/12*7+8*9");

        [Benchmark]
        public void ExpressionCs() => SomeExpression(_clientCs);

        [Benchmark]
        public void ExpressionFs() => SomeExpression(_clientFs);
    }
}