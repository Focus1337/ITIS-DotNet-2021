using System;

namespace Calculator
{
    public class Program
    {
        public static Exception NotEnoughArgs = new Exception("Not enough args");
        public static Exception WrongArgFormat = new Exception("Wrong arg format");
        public static Exception WrongOperation = new Exception("Wrong operation");
        public static Exception AttemptToDivideByZero = new Exception("Attempt to divide by zero");
        
        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLengthOrQuit(args))
                throw NotEnoughArgs;
            
            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
                throw WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
                throw WrongOperation;

            if (Calculator.Calculate(val1, operation, val2, out var result))
                throw AttemptToDivideByZero;

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}