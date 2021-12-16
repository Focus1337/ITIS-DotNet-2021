using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebAppHW10.Models;

namespace WebAppHW10.Controllers
{
    public class CalculatorController : Controller
    {
        // пробел считает за '+', поэтому нельзя использовать пробелы
        [HttpGet, Route("calculator")]
        public IActionResult Calculate(
            [FromServices] ExpressionsCache cache,
            [FromServices] ICachedCalculator calculator,
            string expressionString)
        {
            string AddPluses(string str) =>
                str.Aggregate(new StringBuilder(), (builder, c) => builder.Append(c switch
                {
                    ' ' => "+",
                    '-' => builder.Length is not 0 && !"()*/+-".Contains(builder[^1]) ? "+-" : "-",
                    _ => c.ToString()
                })).ToString();

            expressionString = AddPluses(expressionString);
            Console.WriteLine();
            Console.WriteLine($"получено выражение:\n\t{expressionString}");

            var expression = calculator.FromString(expressionString);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var res1 = calculator.CalculateWithCache(expression, cache);
            stopwatch.Stop();
            Console.WriteLine(
                $"результат через ExpressionCalculator:\n\t{res1.ToString(CultureInfo.InvariantCulture)}");
            return Ok(res1.ToString(CultureInfo.InvariantCulture) +
                      $" заняло времени: {stopwatch.ElapsedMilliseconds} миллисекунд");
        }
    }
}