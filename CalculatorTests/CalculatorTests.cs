using Xunit;
using static Calculator.Calculator;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, Operation.Plus, 4, 8)]
        [InlineData(20, Operation.Plus, 1, 21)]
        [InlineData(14, Operation.Plus, 72, 86)]

        public void Calculate_Val1PlusVal2_ReturnSum(int val1, Operation operation, int val2, int result)
        {
            Assert.Equal(Calculate(val1, operation, val2), result);
        }
       
        [Theory]
        [InlineData(12, Operation.Minus, 6, 6)]
        [InlineData(0, Operation.Minus, 7, -7)]
        [InlineData(257, Operation.Minus, 127, 130)]

        public void Calculate_Val1MinusVal2_ReturnDifference(int val1, Operation operation, int val2, int result)
        {
            Assert.Equal(Calculate(val1, operation, val2), result);
        }
       
        [Theory]
        [InlineData(5, Operation.Multiply, 1, 5)]
        [InlineData(0, Operation.Multiply, 4, 0)]
        [InlineData(30, Operation.Multiply, 6, 180)]

        public void Calculate_Val1MultiplyVal2_ReturnProduct(int val1, Operation operation, int val2, int result)
        {
            Assert.Equal(Calculate(val1, operation, val2), result);
        }

        [Theory]
        [InlineData(20, Operation.Divide, 4, 5)]
        [InlineData(0, Operation.Divide, 11, 0)]
        [InlineData(153, Operation.Divide, 10, 15)]

        public void Calculate_Val1DivideVal2_ReturnQuotient(int val1, Operation operation, int val2, int result)
        {
            Assert.Equal(Calculate(val1, operation, val2), result);
        }
    }
}