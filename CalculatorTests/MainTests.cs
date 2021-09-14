using Xunit;
using static Calculator.Program;

namespace Calculator.Tests
{
    public class MainTests
    {
        [Theory]
        [InlineData(new[] { "1", "+", "2" }, 0)]
        [InlineData(new[] { "3", "-", "4" }, 0)]
        [InlineData(new[] { "5", "*", "6" }, 0)]
        [InlineData(new[] { "77", "/" }, 1)]
        [InlineData(new[] { "3ergerg" }, 1)]
        [InlineData(new[] { "8", "+", "9", "z" }, 1)]
        [InlineData(new[] { "10", "11", "" }, 2)]
        [InlineData(new[] { "hz", "/", "dd" }, 2)]
        [InlineData(new[] { "r", "*", "23" }, 2)]
        [InlineData(new[] { "1", "j", "8" }, 3)]
        [InlineData(new[] { "9", "", "3" }, 3)]
        [InlineData(new[] { "5", "34", "9" }, 3)]
        public void Main_TryParseArgsAndOperator_ReturnErorCode(string[] args, int result)
        {
            Assert.Equal(Main(args), result);
        }
    }
}