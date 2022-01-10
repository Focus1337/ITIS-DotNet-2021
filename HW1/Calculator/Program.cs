using System;
using FSLibrary;

namespace Calculator
{
    public class Program
    {
        public static int Main(string[] args)
        {

            if (ParserFs.CheckArgsLengthOrQuit(args))
                throw CalculatorFs.NotEnoughArgs;

            if (ParserFs.TryParseArgsOrQuit(args[0], out var val1) ||
                ParserFs.TryParseArgsOrQuit(args[1], out var val2))
                throw CalculatorFs.WrongArgFormat;
                
            var operation = ParserFs.ParseCalculatorOperation(args[2]);
            if (operation.Equals(CalculatorFs.Operation.Unassigned))
                throw CalculatorFs.WrongOperation;

            var result = CalculatorFs.Calculate(val1, val2, operation);

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}