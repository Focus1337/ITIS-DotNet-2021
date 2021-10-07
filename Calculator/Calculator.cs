using System;

namespace Calculator
{
    public static class Calculator
    {
        public enum Operation
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }

        public static int Calculate(int val1, int val2, Operation operation)
        {
            switch (operation)
            {
                case Operation.Plus:
                    return val1 + val2;
                case Operation.Minus:
                    return val1 - val2;
                case Operation.Multiply:
                    return val1 * val2;
                case Operation.Divide:
                    if (val2 == 0)
                        throw ParserExceptions.AttemptToDivideByZero;
                    return val1 / val2;
                default:
                    throw ParserExceptions.OutOfRange;
            }
        }
    }
}