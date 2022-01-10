using System;
using Xunit;
using FSLibraryResult;
using Microsoft.FSharp.Core;

namespace FSResultTest
{
    public class CalculatorTests
    {
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
                var plusResult =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Plus));

                var minusResult =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Minus));

                var multiplyResult =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Multiply));

                var divideResult =
                    CalculatorFs.calculate(FSharpResult<double, Exception>.NewOk(i),
                        FSharpResult<double, Exception>.NewOk(j),
                        FSharpResult<CalculatorFs.Operation, Exception>.NewOk(CalculatorFs.Operation.Divide));

                Assert.True(plusResult.IsOk);
                Assert.True(minusResult.IsOk);
                Assert.True(multiplyResult.IsOk);
                Assert.True(divideResult.IsOk);

                Assert.Equal(i + j, plusResult.ResultValue);
                Assert.Equal(i - j, minusResult.ResultValue);
                Assert.Equal(i * j, multiplyResult.ResultValue);
                Assert.Equal(i / j, divideResult.ResultValue);
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
}