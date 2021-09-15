using Xunit;
using static Calculator.Calculator;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, Operation.Plus, 4)]
        [InlineData(20, Operation.Plus, 1)]
        [InlineData(14, Operation.Plus, 72)]
        public void Calculate_Val1PlusVal2_ReturnSum(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 + val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }
        
        [Theory]
        [InlineData(12, Operation.Minus, 6)]
        [InlineData(0, Operation.Minus, 7)]
        [InlineData(257, Operation.Minus, 127)]
        public void Calculate_Val1MinusVal2_ReturnDifference(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 - val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }
        
        [Theory]
        [InlineData(5, Operation.Multiply, 1)]
        [InlineData(0, Operation.Multiply, 4)]
        [InlineData(30, Operation.Multiply, 6)]
        public void Calculate_Val1MultiplyVal2_ReturnProduct(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 * val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(20, Operation.Divide, 4)]
        [InlineData(0, Operation.Divide, 11)]
        [InlineData(153, Operation.Divide, 10)]
        public void Calculate_Val1DivideVal2_ReturnQuotient(int val1, Operation operation, int val2)
        {
            var resultExpected = val1 / val2;
            Calculate(val1, operation, val2, out var result);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(235, Operation.Divide, 0)]
        public void Calculate_Val1DivideZero_ReturnTrue(int val1, Operation operation, int val2)
        {
            Assert.True(Calculate(val1, operation, val2, out var result));
        }
    }
}