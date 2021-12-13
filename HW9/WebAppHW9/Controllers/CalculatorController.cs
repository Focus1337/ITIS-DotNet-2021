using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebAppHW9.Models;

namespace WebAppHW9.Controllers
{
    public class CalculatorController : Controller
    {
        /// пробел считает за '+', поэтому их нельзя использовать
        [HttpGet, Route("calc")]
        public IActionResult Calculate(string expressionString)
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
            Console.WriteLine($"полечено выражение:\n\t{expressionString}");

            var expression = ExpressionCalculator.FromString(expressionString);
            var res = ExpressionCalculator.ExecuteSlowly(expression);
            Console.WriteLine($"результат через ExpressionCalculator:\n\t{res?.ToString(CultureInfo.InvariantCulture) ?? "ошибка"}");
            return Ok(res?.ToString(CultureInfo.InvariantCulture) ?? "ошибка");
        }
    }
}