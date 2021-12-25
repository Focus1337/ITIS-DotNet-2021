using System.Linq;
using System.Text;

namespace WebAppHW13.Models;

public static class ExpressionFixer
{
    public static string Fix(string expressionString) =>
        expressionString.Aggregate(new StringBuilder(), (builder, c) => builder.Append(c switch
        {
            ' ' => "+",
            '-' => builder.Length is not 0 && !"()*/+-".Contains(builder[^1]) ? "+-" : "-",
            _ => c.ToString()
        })).ToString();
}