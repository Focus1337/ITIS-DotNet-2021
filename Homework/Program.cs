using System;

namespace Calculator
{
    public class Program
    {
        private const int NotEnoughtArgs = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;

        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLengthOrQuit(args))
                return NotEnoughtArgs;

            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
                return WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
                return WrongOperation;

            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}