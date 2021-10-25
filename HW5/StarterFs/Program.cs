using System;
using FSLibraryRCE;

namespace StarterFs
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 3)
                throw CalculatorFs.NotEnoughArgs;

            var num1Res = ParserFs.parseInt(args[0]);
            var num2Res = ParserFs.parseInt(args[2]);
            var operationRes = ParserFs.parseCalculatorOperation(args[1]);

            if (num1Res.IsError)
                throw CalculatorFs.WrongArgFormat;
            if (num2Res.IsError)
                throw CalculatorFs.WrongArgFormat;
            if (operationRes.IsError)
                throw CalculatorFs.WrongOperation;

            var calculationRes = CalculatorFs.calculate(num1Res, num2Res, operationRes);

            //if (calculationRes.IsError)
            //    throw new Exception(calculationRes.ErrorValue);

            var result = calculationRes.ResultValue;

            Console.WriteLine($"Result : {result}");

            return 0;


            // if (ParserFs.CheckArgsLengthOrQuit(args))
            //     throw CalculatorFs.NotEnoughArgs;
            //
            // if (ParserFs.TryParseArgsOrQuit(args[0], out var val1) ||
            //     ParserFs.TryParseArgsOrQuit(args[1], out var val2))
            //     throw CalculatorFs.WrongArgFormat;
            //     
            // var operation = ParserFs.ParseCalculatorOperation(args[2]);
            // if (operation.Equals(CalculatorFs.Operation.Unassigned))
            //     throw CalculatorFs.WrongOperation;
            //
            // var result = CalculatorFs.Calculate(val1, val2, operation);
            //
            // Console.WriteLine($"Result : {result}");
            //
            // return 0;
        }
    }
}