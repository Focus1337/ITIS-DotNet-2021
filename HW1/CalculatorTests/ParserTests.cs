using System;
using Calculator;
using Xunit;

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
            var expResult = Parser.TryParseOperatorOrQuit(arg, out _);
            Assert.Equal(expResult, result);
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
            var expResult = Parser.TryParseArgsOrQuit(arg, out _);
            Assert.Equal(expResult, result);
        }

        [Theory]
        [InlineData(new[] {"1", "2", "3"}, false)]
        [InlineData(new[] {"f", "'", "z"}, false)]
        [InlineData(new[] {"1daw", "7ryhe", "f'g1d"}, false)]
        [InlineData(new[] {"4", "5"}, true)]
        [InlineData(new[] {"6", "7", "8", "jhgj2"}, true)]
        [InlineData(new[] {""}, true)]
        public void CheckArgsLengthOrQuit_ReturnFalseOrTrue(string[] args, bool result)
        {
            var expResult = Parser.CheckArgsLengthOrQuit(args);
            Assert.Equal(expResult, result);
        }
    }

    public class ParserExceptionsTests
    {
        [Theory]
        [InlineData("1", "2", "+")]
        [InlineData("3", "4", "-")]
        [InlineData("5", "6","*")]
        [InlineData("77", "/")]
        [InlineData("3ergerg")]
        [InlineData("8", "9", "z", "+")]
        public void TryParseArgsAndOperator_ReturnNotEnoughArgsException(params string[] args)
        {
            try
            {
                Program.Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(ParserExceptions.NotEnoughArgs, e);
            }
        }

        [Theory]
        [InlineData("5", "2", "+")]
        [InlineData("9", "4", "-")]
        [InlineData("15", "6", "*")]
        [InlineData("10", "", "11")]
        [InlineData("hz", "dd", "/")]
        [InlineData("r", "23", "*")]
        public void TryParseArgsAndOperator_ReturnWrongArgFormatException(params string[] args)
        {
            try
            {
                Program.Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(ParserExceptions.WrongArgFormat, e);
            }
        }

        [Theory]
        [InlineData("1", "2", "+")]
        [InlineData("3", "4", "-")]
        [InlineData("5", "6", "*")]
        [InlineData("1", "8", "j")]
        [InlineData("9", "3", "")]
        [InlineData("5", "34", "9")]
        [InlineData("2", "1", "/")]
        public void TryParseArgsAndOperator_ReturnWrongOperationException(params string[] args)
        {
            try
            {
                Program.Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(ParserExceptions.WrongOperation, e);
            }
        }

        [Theory]
        [InlineData("1", "2", "+")]
        [InlineData("3", "4", "-")]
        [InlineData("5", "6", "*")]
        [InlineData("5", "0", "/")]
        public void TryParseArgsAndOperator_ReturnAttemptToDivideByZeroException(params string[] args)
        {
            try
            {
                Program.Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(ParserExceptions.AttemptToDivideByZero, e);
            }
        }
        
        [Theory]
        [InlineData("1", "2", "2")]
        [InlineData("3", "4", "4")]
        [InlineData("5", "6", "5")]
        [InlineData("5", "0", "8")]
        public void TryParseArgsAndOperator_OutOfRangeException(params string[] args)
        {
            try
            {
                Calculator.Calculator.Calculate(Convert.ToInt32(args[0]),
                    Convert.ToInt32(args[1]),
                    (Calculator.Calculator.Operation) Convert.ToInt32(args[2]));
            }
            catch (Exception e)
            {
                Assert.Equal(ParserExceptions.OutOfRange, e);
            }
        }
    }
}