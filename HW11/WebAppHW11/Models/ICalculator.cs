namespace WebAppHW11.Models
{
    public interface ICalculator
    {
        decimal Calculate(decimal num1, decimal num2, Operation operation);
    }
}