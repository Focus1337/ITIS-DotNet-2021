using System;
using Xunit;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace WebApplication.Tests
{
    public class ResponseTests
    {
        private readonly HttpClient _client;

        public ResponseTests()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        private async Task<decimal> Action(decimal v1, decimal v2, string operation)
        {
            var response = await _client.GetAsync($"http://localhost:5000/calc?v1={v1}&v2={v2}&op={operation}");

            var strNumber = await response.Content.ReadAsStringAsync();
            decimal parsed;
            
            try
            {
                parsed = decimal.Parse(strNumber, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception($"Impossible to parse: {strNumber}");
            }

            return parsed;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 2, 5)]
        [InlineData(44, 22, 66)]
        [InlineData(345, 2134, 2479)]
        public async Task SumDecimalTests(decimal v1, decimal v2, decimal exp)
        {
            var sum = await Action(v1, v2, "sum");
            Assert.True(Math.Round(exp - sum) < 0.0001m);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(3, 2, 1)]
        [InlineData(44, 22, 22)]
        [InlineData(345, 2134, -1789)]
        public async Task MinusDecimalTests(decimal v1, decimal v2, decimal exp)
        {
            var dif = await Action(v1, v2, "dif");
            Assert.True(Math.Round(exp - dif) < 0.0001m);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(3, 2, 6)]
        [InlineData(44, 22, 968)]
        [InlineData(345, 2134, 736230)]
        public async Task MultiplyDecimalsTests(decimal v1, decimal v2, decimal exp)
        {
            var mult = await Action(v1, v2, "mult");
            Assert.True(Math.Round(exp - mult) < 0.0001m);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(3, 2, 1.5)]
        [InlineData(44, 22, 2)]
        [InlineData(345, 2134, 0.161668228678538)]
        public async Task DivideDecimalsTests(decimal v1, decimal v2, decimal exp)
        {
            var div = await Action(v1, v2, "div");
            Assert.True(Math.Round(exp - div) < 0.0001m);
        }

        [Fact]
        public async Task SomeFails()
        {
            var response = await _client.GetAsync("http://localhost:5000/calc?v1=10");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
            response = await _client.GetAsync("http://localhost:5000/calc?v1=1&v2=2&op=kek");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal((HttpStatusCode) 450, response.StatusCode);
            Assert.Equal($"\"{FSLibraryResult.CalculatorFs.WrongOperation}\"", responseString);
        
            response = await _client.GetAsync("http://localhost:5000/calc?v1=1&v2=0&op=div");
            responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal($"\"{FSLibraryResult.CalculatorFs.AttemptToDivideByZero}\"", responseString);
        }
    }
}