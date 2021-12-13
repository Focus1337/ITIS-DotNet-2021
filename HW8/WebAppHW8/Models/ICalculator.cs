using WepApp.Controllers;

namespace WepApp.Models
{
    public interface ICalculator
    {
        decimal Calculate(CalculatorArgs args);
    }
}