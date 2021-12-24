using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Testing;
using WebAppHW13;

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
           // _clientFs = new WebApplicationFactory<GiraffeHW12.Startup>().CreateClient();
        }
        
        private static void Sum(HttpClient client) =>
            client.GetAsync("https://localhost:5001/calculate?expressionString=2+3");

        [Benchmark]
        public void SumCs() => Sum(_clientCs);

        [Benchmark]
        public void SumFs() => Sum(_clientFs);

        private static void SomeExpression(HttpClient client) =>
            client.GetAsync("https://localhost:5001/calculate?expressionString=(5+34)/11*8*9+5");

        [Benchmark]
        public void ExpressionCs() => SomeExpression(_clientCs);

        [Benchmark]
        public void ExpressionFs() => SomeExpression(_clientFs);
    }
}