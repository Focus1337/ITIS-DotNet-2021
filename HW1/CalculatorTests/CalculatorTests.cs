using Xunit;
using static Calculator.Calculator;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, 4, Operation.Plus)]
        [InlineData(20, 1, Operation.Plus)]
        [InlineData(14, 72, Operation.Plus)]
        public void Calculate_Val1PlusVal2_ReturnSum(int val1, int val2, Operation operation)
        {
            var resultExpected = val1 + val2;
            var result = Calculate(val1, val2, operation);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(12, 6,Operation.Minus)]
        [InlineData(0, 7,Operation.Minus)]
        [InlineData(257, 127,Operation.Minus)]
        public void Calculate_Val1MinusVal2_ReturnDifference(int val1, int val2, Operation operation)
        {
            var resultExpected = val1 - val2;
            var result = Calculate(val1, val2, operation);
            Assert.Equal(resultExpected, result);
        }
        
        [Theory]
        [InlineData(5, 1, Operation.Multiply)]
        [InlineData(0, 4, Operation.Multiply)]
        [InlineData(30, 6, Operation.Multiply)]
        public void Calculate_Val1MultiplyVal2_ReturnProduct(int val1, int val2, Operation operation)
        {
            var resultExpected = val1 * val2;
            var result = Calculate(val1, val2, operation);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(20, 4, Operation.Divide)]
        [InlineData(0, 11, Operation.Divide)]
        [InlineData(153, 10, Operation.Divide)]
        public void Calculate_Val1DivideVal2_ReturnQuotient(int val1, int val2, Operation operation)
        {
            var resultExpected = val1 / val2;
            var result = Calculate(val1, val2, operation);
            Assert.Equal(resultExpected, result);
        }
    }
}