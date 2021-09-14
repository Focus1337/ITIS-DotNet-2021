using Xunit;
using static Calculator.Parser;
using static Calculator.Calculator;

namespace Calculator.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("+", false)]
        [InlineData("-", false)]
        [InlineData("*", false)]
        [InlineData("/", false)]
        [InlineData("6", true)]
        [InlineData("33", true)]
        [InlineData("++", true)]
        public void TryParseOperatorOrQuit_ReturnFalseOrTrue(string arg, bool result)
        {
            Assert.Equal(TryParseOperatorOrQuit(arg, out Operation operation), result);
        }

        [Theory]
        [InlineData("21", false)]
        [InlineData("15", false)]
        [InlineData("87", false)]
        [InlineData("545", false)]
        [InlineData("-", true)]
        [InlineData("6ghj", true)]
        [InlineData("++", true)]
        public void TryParseArgOrQuit_ReturnFalseOrTrue(string arg, bool result)
        {
            Assert.Equal(TryParseArgsOrQuit(arg, out int methodResult), result);
        }

        [Theory]
        [InlineData(new[] { "1", "2", "3" }, false)]
        [InlineData(new[] { "f", "'", "z" }, false)]
        [InlineData(new[] { "1daw", "7ryhe", "f'g1d" }, false)]
        [InlineData(new[] { "4", "5" }, true)]
        [InlineData(new[] { "6", "7", "8", "jhgj2" }, true)]
        [InlineData(new[] { "" }, true)]
        public void CheckArgsLengthOrQuit_ReturnFalseOrTrue(string[] args, bool result)
        {
            Assert.Equal(CheckArgsLengthOrQuit(args), result);
        }
    }
}