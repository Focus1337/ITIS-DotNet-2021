using Xunit;
using static Calculator.Parser;
using static Calculator.Calculator;
using static Calculator.Program;

namespace CalculatorTests
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
        [InlineData(new[] { "5", "/", "0" }, 4)]
         public void Main_TryParseArgsAndOperator_ReturnErrorCode(string[] args, int result)
         {
             Assert.Equal(Main(args), result);
         }
    }
}