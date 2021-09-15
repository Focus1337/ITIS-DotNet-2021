using System;

namespace Calculator
{
    public class Program
    {
        private const int NotEnoughArgs = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;
        private const int AttemptToDivideByZero = 4;

        // public static int Main(string[] args)
        // {
        //     if (Parser.CheckArgsLengthOrQuit(args))
        //         return NotEnoughArgs;
        //
        //     if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
        //         return WrongArgFormat;
        //
        //     if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
        //         return WrongOperation;
        //
        //     var result = Calculator.Calculate(val1, operation, val2);
        //     Console.WriteLine($"Result : {result}");
        //
        //     return 0;
        // }
        
        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLengthOrQuit(args))
                return NotEnoughArgs;

            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
                return WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
                return WrongOperation;

            if (Calculator.Calculate(val1, operation, val2, out var result))
                return AttemptToDivideByZero;

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}