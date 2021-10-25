using System;
using Xunit;
using static StarterFs.Program;
using FSLibraryRCE;
using Microsoft.FSharp.Core;

namespace FSRCETest
{
    public class CalculatorTests
    {
        [Fact]
        public void DivBy0()
        {
            var res = CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(2),
                FSharpResult<int, Exception>.NewOk(0),
                FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));
            Assert.True(res.IsError);
            Assert.Equal(CalculatorFs.AttemptToDivideByZero, res.ErrorValue);
        }

        [Fact]
        public void CalculateInts()
        {
            for (var i = 0; i < 20; ++i)
            for (var j = 1; j < 21; ++j)
            {
                var plusRes =
                    CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(i), FSharpResult<int, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Plus));
                var minusRes =
                    CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(i), FSharpResult<int, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Minus));
                var multiplicationRes =
                    CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(i), FSharpResult<int, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Multiply));
                var divRes =
                    CalculatorFs.calculate(FSharpResult<int, Exception>.NewOk(i), FSharpResult<int, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));

                Assert.True(plusRes.IsOk);
                Assert.True(minusRes.IsOk);
                Assert.True(multiplicationRes.IsOk);
                Assert.True(divRes.IsOk);


                Assert.Equal(i + j, plusRes.ResultValue);
                Assert.Equal(i - j, minusRes.ResultValue);
                Assert.Equal(i * j, multiplicationRes.ResultValue);
                Assert.Equal(i / j, divRes.ResultValue);
            }
        }

        [Fact]
        public void CalculateDoubles()
        {
            for (var i = 0.5; i < 20; ++i)
            for (var j = 1.5; j < 21; ++j)
            {
                var plusRes =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Plus));
                var minusRes =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Minus));
                var multiplicationRes =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Multiply));
                var divRes =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));

                Assert.True(plusRes.IsOk);
                Assert.True(minusRes.IsOk);
                Assert.True(multiplicationRes.IsOk);
                Assert.True(divRes.IsOk);

                Assert.Equal(i + j, plusRes.ResultValue);
                Assert.Equal(i - j, minusRes.ResultValue);
                Assert.Equal(i * j, multiplicationRes.ResultValue);
                Assert.Equal(i / j, divRes.ResultValue);
            }
        }

        [Fact]
        public void CalculateDecimals()
        {
            for (var i = 0.5m; i < 20; ++i)
            for (var j = 1.5m; j < 21; ++j)
            {
                var plusRes =
                    CalculatorFs.calculate(FSharpResult<decimal, Exception>.NewOk(i),
                        FSharpResult<decimal, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Plus));
                var minusRes =
                    CalculatorFs.calculate(FSharpResult<decimal, Exception>.NewOk(i),
                        FSharpResult<decimal, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Minus));
                var multiplicationRes =
                    CalculatorFs.calculate(FSharpResult<decimal, Exception>.NewOk(i),
                        FSharpResult<decimal, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Multiply));
                var divRes =
                    CalculatorFs.calculate(FSharpResult<decimal, Exception>.NewOk(i),
                        FSharpResult<decimal, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));

                Assert.True(plusRes.IsOk);
                Assert.True(minusRes.IsOk);
                Assert.True(multiplicationRes.IsOk);
                Assert.True(divRes.IsOk);

                Assert.Equal(i + j, plusRes.ResultValue);
                Assert.Equal(i - j, minusRes.ResultValue);
                Assert.Equal(i * j, multiplicationRes.ResultValue);
                Assert.Equal(i / j, divRes.ResultValue);
            }
        }
    }


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
            var res1 = ParserFs.parseInt("1");
            Assert.True(res1.IsOk);
            Assert.Equal(1, res1.ResultValue);
            var res2 = ParserFs.parseDouble("1");
            Assert.True(res2.IsOk);
            Assert.Equal(1.0, res2.ResultValue);
            var res3 = ParserFs.parseDecimal("1");
            Assert.True(res3.IsOk);
            Assert.Equal(1m, res3.ResultValue);
            var res4 = ParserFs.parseFloat("1");
            Assert.True(res4.IsOk);
            Assert.Equal(1.0f, res4.ResultValue);
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

        // [Theory]
        // [InlineData("1", "2", "+")]
        // [InlineData("3", "4", "-")]
        // [InlineData("5", "6", "*")]
        // [InlineData("5", "0", "/")]
        // public void TryParseArgsAndOperator_ReturnAttemptToDivideByZeroException(params string[] args)
        // {
        //     try
        //     {
        //         Main(args);
        //     }
        //     catch (Exception e)
        //     {
        //         Assert.Equal(CalculatorFS.AttemptToDivideByZero, e);
        //     }
        // }
    }
}