using System;
namespace Calculator
{
    public static class ParserExceptions
    {
        public static readonly Exception NotEnoughArgs = new("Not enough args");
        public static readonly Exception WrongArgFormat = new("Wrong arg format");
        public static readonly Exception WrongOperation = new("Wrong operation");
        public static readonly Exception AttemptToDivideByZero = new DivideByZeroException("Attempt to divide by zero");
        public static readonly Exception OutOfRange = new ArgumentOutOfRangeException($"Arg Out of range");
    }
    
    public static class Parser
    {
        public static bool TryParseOperatorOrQuit(string arg, out Calculator.Operation operation)
        {
            switch (arg)
            {
                case "+":
                    operation = Calculator.Operation.Plus;
                    break;
                case "-":
                    operation = Calculator.Operation.Minus;
                    break;
                case "*":
                    operation = Calculator.Operation.Multiply;
                    break;
                case "/":
                    operation = Calculator.Operation.Divide;
                    break;
                default:
                    operation = default;
                    return true;
            }
        
            return false;
        }

        public static bool TryParseArgsOrQuit(string arg, out int val)
        {
            if (int.TryParse(arg, out val)) 
                return false;
            Console.WriteLine($"Value isn't int: {arg}");
            return true;
        }

        public static bool CheckArgsLengthOrQuit(string[] args)
        {
            if (args.Length == 3)
                return false;
            Console.WriteLine($"The program requires 3 CLI arguments, but {args.Length} provided");
            return true;
        }
    }
}