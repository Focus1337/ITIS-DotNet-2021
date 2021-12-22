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
        private HttpClient _clientCs;
        private HttpClient _clientFs;

        public Ebenchmark()
        {
            _clientCs = new WebApplicationFactory<Startup>().CreateClient();
        }

        private const string ResponseBody = "https://localhost:5001/calculate?expressionString=";

        [Benchmark]
        public async Task SumCSharp()
        {
            var response = await _clientCs.GetAsync($"{ResponseBody}2+3");
        }
    }
}