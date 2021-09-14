using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public static class Calculator
    {
        public enum Operation : byte
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }

        public static int Calculate(int val1, int val2, Operation operation)
        {
            return operation switch
            {
                Operation.Plus => val1 + val2,
                Operation.Minus => val1 - val2,
                Operation.Multiply => val1 * val2,
                Operation.Divide => val1 / val2,
                _ => throw new NotImplementedException()
            };
        }
    }
}
