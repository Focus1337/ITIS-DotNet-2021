using System;

namespace WebAppHW10.Models
{
    internal class Calculator : ICalculator
    {
        public decimal Calculate(decimal num1, decimal num2, Operation operation) => operation switch
        {
            Operation.Plus => num1 + num2,
            Operation.Minus => num1 - num2,
            Operation.Mult => num1 * num2,
            Operation.Div => num1 / num2,
            _ => throw new Exception("Wrong operation")
        };
    }
}