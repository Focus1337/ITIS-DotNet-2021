using System;

namespace Calculator
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLengthOrQuit(args))
                throw ParserExceptions.NotEnoughArgs;
            
            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[1], out var val2))
                throw ParserExceptions.WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[2], out var operation))
                throw ParserExceptions.WrongOperation;

            var result = Calculator.Calculate(val1, val2, operation);
            
            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}