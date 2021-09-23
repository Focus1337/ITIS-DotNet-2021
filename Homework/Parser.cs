using System;
namespace Calculator
{
    public static class Parser
    {
        public static bool TryParseOperatorOrQuit(string arg, out Calculator.Operation operation)
        {
            if (arg == "+")
                operation = Calculator.Operation.Plus;
            else if (arg == "-")
                operation = Calculator.Operation.Minus;
            else if (arg == "*")
                operation = Calculator.Operation.Multiply;
            else if (arg == "/")
                operation = Calculator.Operation.Divide;
            else
            {
                operation = default;
                return true;
            }

            return false;
        }

        public static bool TryParseArgsOrQuit(string arg, out int result)
        {
            if (int.TryParse(arg, out result))
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