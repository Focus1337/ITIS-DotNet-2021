using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppHW13.Models;
using WebAppHW13.Services;

namespace WebAppHW13.Controllers;

public class CalculatorController : Controller
{
    private readonly ExceptionHandler _exceptionHandler;

    public CalculatorController(ExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
    }
        
    // пробел считает за '+', поэтому нельзя использовать пробелы
    [HttpGet, Route("calculate")]
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

        Expression expression;
        try
        {
            expression = calculator.FromString(expressionString);
        }
        catch (Exception e)
        {
            _exceptionHandler.DoHandle(LogLevel.Error, e);
            return BadRequest();
        }
            
        decimal result;
        try
        {
            result = calculator.CalculateWithCache(expression, cache);
        }
        catch (Exception e)
        {
            _exceptionHandler.DoHandle(LogLevel.Error, e);
            return BadRequest();
        }

        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }
}