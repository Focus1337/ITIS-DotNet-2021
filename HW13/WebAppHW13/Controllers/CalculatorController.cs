using Microsoft.AspNetCore.Mvc;
using WebAppHW13.Models;

namespace WebAppHW13.Controllers;

public class CalculatorController : Controller
{
    [HttpGet, Route("calculate")]
    public IActionResult Calculate(
        [FromServices] ExpressionsCache cache,
        [FromServices] ICachedCalculator calculator,
        string expressionString)
    {
        expressionString = ExpressionFixer.Fix(expressionString);

        var expression = calculator.FromString(expressionString);

        var result = calculator.CalculateWithCache(expression, cache);

        return View(result);
    }
}