using System;
using FSLibraryResult;
using Microsoft.FSharp.Core;
using StarterFs;
using Xunit;

namespace FSResultTest
{
    public class ParserTests
    {
        [Fact]
        public void WrongOperation()
        {
            var res = ParserFs.parseCalculatorOperation("ff");
            Assert.True(res.IsError);
            Assert.Equal(CalculatorFs.WrongOperation, res.ErrorValue);
        }

        [Fact]
        public void WrongArgFormat()
        {
            var res = ParserFs.parseInt("a");
            Assert.True(res.IsError);
            Assert.Equal(CalculatorFs.WrongArgFormat, res.ErrorValue);
        }

        [Fact]
        public void AllTypes()
        {
            var intResult = ParserFs.parseInt("1");
            var doubleResult = ParserFs.parseDouble("1");
            var decimalResult = ParserFs.parseDecimal("1");
            var floatResult = ParserFs.parseFloat("1");

            Assert.True(intResult.IsOk);
            Assert.True(doubleResult.IsOk);
            Assert.True(decimalResult.IsOk);
            Assert.True(floatResult.IsOk);

            Assert.Equal(1, intResult.ResultValue);
            Assert.Equal(1.0, doubleResult.ResultValue);
            Assert.Equal(1m, decimalResult.ResultValue);
            Assert.Equal(1.0f, floatResult.ResultValue);
        }

        [Fact]
        public void Parse()
        {
            var resPlus = ParserFs.parseCalculatorOperation("+");
            var resMinus = ParserFs.parseCalculatorOperation("-");
            var resMultiplication = ParserFs.parseCalculatorOperation("*");
            var resDiv = ParserFs.parseCalculatorOperation("/");

            Assert.True(resPlus.IsOk);
            Assert.True(resMinus.IsOk);
            Assert.True(resMultiplication.IsOk);
            Assert.True(resDiv.IsOk);

            Assert.Equal(CalculatorFs.Operation.Plus, resPlus.ResultValue);
            Assert.Equal(CalculatorFs.Operation.Minus, resMinus.ResultValue);
            Assert.Equal(CalculatorFs.Operation.Multiply, resMultiplication.ResultValue);
            Assert.Equal(CalculatorFs.Operation.Divide, resDiv.ResultValue);
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
                Program.Main(args);
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
                Program.Main(args);
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
                Program.Main(args);
            }
            catch (Exception e)
            {
                Assert.Equal(CalculatorFs.WrongOperation, e);
            }
        }

        [Fact]
        public void TryParseArgsAndOperator_ReturnAttemptToDivideByZeroException()
        {
            var actualResult = CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(2),
                FSharpResult<int, Exception>.NewOk(0),
                FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));

            Assert.True(actualResult.IsError);
            Assert.Equal(CalculatorFs.AttemptToDivideByZero, actualResult.ErrorValue);
        }
    }
}