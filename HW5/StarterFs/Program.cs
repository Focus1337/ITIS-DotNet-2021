using System;
using FSLibraryResult;

namespace StarterFs
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 3)
                throw CalculatorFs.NotEnoughArgs;

            var val1 = ParserFs.parseInt(args[0]);
            var val2 = ParserFs.parseInt(args[1]);
            var operation = ParserFs.parseCalculatorOperation(args[2]);

            if (val1.IsError || val2.IsError) 
                throw CalculatorFs.WrongArgFormat;

            if (operation.IsError)
                throw CalculatorFs.WrongOperation;
            
            var result = CalculatorFs.calculate(val1, val2, operation).ResultValue;

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}