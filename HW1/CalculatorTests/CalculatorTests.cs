using Xunit;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, 4)]
        [InlineData(20, 1)]
        [InlineData(14, 72)]
        public void Calculate_Val1PlusVal2_ReturnSum(int val1, int val2)
        {
            var resultExpected = val1 + val2;
            var result = FSLibrary.CalculatorFs.Calculate(val1, val2, FSLibrary.CalculatorFs.Operation.Plus);
            Assert.Equal(resultExpected, result);
        }
        
        [Theory]
        [InlineData(12, 6)]
        [InlineData(0, 7)]
        [InlineData(257, 127)]
        public void Calculate_Val1MinusVal2_ReturnDifference(int val1, int val2)
        {
            var resultExpected = val1 - val2;
            var result = FSLibrary.CalculatorFs.Calculate(val1, val2, FSLibrary.CalculatorFs.Operation.Minus);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(5, 1)]
        [InlineData(0, 4)]
        [InlineData(30, 6)]
        public void Calculate_Val1MultiplyVal2_ReturnProduct(int val1, int val2)
        {
            var resultExpected = val1 * val2;
            var result = FSLibrary.CalculatorFs.Calculate(val1, val2, FSLibrary.CalculatorFs.Operation.Multiply);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(20, 4)]
        [InlineData(0, 11)]
        [InlineData(153, 10)]
        public void Calculate_Val1DivideVal2_ReturnQuotient(int val1, int val2)
        {
            var resultExpected = val1 / val2;
            var result = FSLibrary.CalculatorFs.Calculate(val1, val2, FSLibrary.CalculatorFs.Operation.Divide);
            Assert.Equal(resultExpected, result);
        }
    }
}