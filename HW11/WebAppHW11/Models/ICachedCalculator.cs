using System.Linq.Expressions;

namespace WebAppHW11.Models
{
    public interface ICachedCalculator
    {
        Expression FromString(string str);
        decimal CalculateWithCache(Expression expression, ExpressionsCache cache);
    }
}