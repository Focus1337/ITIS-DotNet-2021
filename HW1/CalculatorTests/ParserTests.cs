using System;
using FSLibrary;
using Xunit;
using static Calculator.Program;

namespace CalculatorTests
{
    public class ParserTests
    {
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
            var resultExpected = ParserFs.TryParseArgsOrQuit(arg, out _);
            Assert.Equal(resultExpected, result);
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
            var resultExpected = ParserFs.CheckArgsLengthOrQuit(args);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData("1", "2", "+")]
        [InlineData("3", "4", "-")]
        [InlineData("5", "6", "*")]
        [InlineData("77", "/")]
        [InlineData("3ergerg")]
        [InlineData("8", "9", "z", "+")]
        public void TryParseArgsAndOperator_ReturnNotEnoughArgsException(params string[] args)
        {
            try
            {
                Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorFs.NotEnoughArgs, e);
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
                Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorFs.WrongArgFormat, e);
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
                Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorFs.WrongOperation, e);
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
                Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorFs.AttemptToDivideByZero, e);
            }
        }

      /* CAN'T BE COVERED WITH TEST BECAUSE OF F# TYPE (analogue of enums) */
        
        // [Theory]
        // [InlineData(1, 2)]
        // [InlineData(3, 4)]
        // [InlineData(5, 6)]
        // [InlineData(5, 0)]
        // public void TryParseArgsAndOperator_OutOfRangeException(int val1, int val2)
        // {
        //     try
        //     {
        //         CalculatorFs.Calculate(val1, val2, CalculatorFs.Operation.Unassigned);
        //     }
        //     catch (Exception e)
        //     {
        //         Assert.Equal(CalculatorFs.OutOfRange, e);
        //     }
        // }
    }
}