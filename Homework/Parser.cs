using System;
namespace Calculator
{
    public static class ParserExceptions
    {
        public static readonly Exception NotEnoughArgs = new Exception("Not enough args");
        public static readonly Exception WrongArgFormat = new Exception("Wrong arg format");
        public static readonly Exception WrongOperation = new Exception("Wrong operation");
        public static readonly Exception AttemptToDivideByZero = new Exception("Attempt to divide by zero");
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
            };
            return false;
        }
        public static bool TryParseArgsOrQuit(string arg, out int result)
        {
            if (!int.TryParse(arg, out result))
            {
                Console.WriteLine($"Value isn't int: {arg}");
                return true;
            }
            return false;
        }

        public static bool CheckArgsLengthOrQuit(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine($"The program requires 3 CLI arguments, but {args.Length} provided");
                return true;
            }
            return false;
        }
    }
}