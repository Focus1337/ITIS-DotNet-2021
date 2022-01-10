using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using WepApp;
using WepApp.Controllers;
using WepApp.Models;
using Xunit;

namespace WebAppTests
{
    public class UnitTest
    {
        private readonly CalculatorAdapter _calculator = new();

        [Theory]
        [InlineData(1, "add", 2, 3)]
        [InlineData(3, "add", 2, 5)]
        [InlineData(12.4, "sub", 2.6, 9.8)]
        public void Calculate(decimal val1, string operation, decimal val2, decimal result)
        {
            var actual = _calculator.Calculate(new CalculatorArgs
            {
                Val1 = val1.ToString(),
                Val2 = val2.ToString(),
                Op = operation
            });
            Assert.Equal(result, actual);
        }

        [Fact]
        public void DivideByZero()
        {
            try
            {
                _calculator.Calculate(new CalculatorArgs
                {
                    Val1 = 1.ToString(),
                    Val2 = 0.ToString(),
                    Op = "div"
                });
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorAdapter.CalculationException, e);
            }
        }
    }

    public class IntegrationTest
    {
        private readonly HttpClient _client;

        public IntegrationTest()
        {
            var factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
        }

        private async Task<decimal> Action(decimal v1, decimal v2, string operation)
        {
            var response = await _client.GetAsync($"http://localhost:5000/calculate?val1={v1}&val2={v2}&op={operation}");

            var strNumber = await response.Content.ReadAsStringAsync();
            decimal parsed;
            try
            {
                parsed = decimal.Parse(strNumber, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception($"Impossible to parse. The number is {strNumber}");
            }

            return parsed;
        }

        private async Task<decimal> Add(decimal v1, decimal v2) =>
            await Action(v1, v2, "add");

        private async Task<decimal> Sub(decimal v1, decimal v2) =>
            await Action(v1, v2, "sub");

        private async Task<decimal> Multiply(decimal v1, decimal v2) =>
            await Action(v1, v2, "mult");

        private async Task<decimal> Divide(decimal v1, decimal v2) =>
            await Action(v1, v2, "div");

        private static void CheckEquality(decimal v1, decimal v2) =>
            Assert.True(Math.Round(v1 - v2) < 0.0001m);

        [Theory]
        [InlineData(2, 3)]
        [InlineData(4, 1)]
        [InlineData(16.4, 22.6)]
        public async Task Calculate(decimal val1, decimal val2)
        {
            CheckEquality(await Add(val1, val2), val1 + val2);
            CheckEquality(await Sub(val1, val2), val1 - val2);
            CheckEquality(await Multiply(val1, val2), val1 * val2);
            CheckEquality(await Divide(val1, val2), val1 / val2);
        }
    }
}