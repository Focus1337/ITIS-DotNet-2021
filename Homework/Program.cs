using System;

namespace Calculator
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLengthOrQuit(args))
                throw ParserExceptions.NotEnoughArgs;
            
            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
                throw ParserExceptions.WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
                throw ParserExceptions.WrongOperation;

            if (Calculator.Calculate(val1, operation, val2, out var result))
                throw ParserExceptions.AttemptToDivideByZero;

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}