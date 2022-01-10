using System;
using FSLibraryResult;
using WepApp.Controllers;

namespace WepApp.Models
{
    public class CalculatorAdapter : ICalculator
    {
        public static readonly Exception CalculationException = new("Impossible to calculate");
        
        public decimal Calculate(CalculatorArgs args)
        {
            var operationParsed = args.Op switch
            {
                "add" => ParserFs.parseCalculatorOperation("+"),
                "sub" => ParserFs.parseCalculatorOperation("-"),
                "mult" => ParserFs.parseCalculatorOperation("*"),
                "div" => ParserFs.parseCalculatorOperation("/"),
                _ => ParserFs.parseCalculatorOperation(default)
            };
            var result = CalculatorFs.calculate(
                ParserFs.parseDecimal(args.Val1),
                ParserFs.parseDecimal(args.Val2),
                operationParsed);
            return result.IsOk ? result.ResultValue : throw CalculationException;
        }
    }
}