using System;
using Microsoft.AspNetCore.Mvc;
using WepApp.Models;

namespace WepApp.Controllers
{
    public class CalculatorController : Controller
    {
        //https://localhost:5001/calc?val1=6&val2=3&op=div
        [HttpGet, Route("calculate")]
        public IActionResult Calc([FromServices] ICalculator calculator, [FromQuery] CalculatorArgs args)
        {
            try
            {
                return Ok(calculator.Calculate(args));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ObjectResult(e.Message)
                {
                    StatusCode = 450
                };
            }
        }
    }
    
    public class CalculatorArgs
    {
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Op { get; set; }
    }
}