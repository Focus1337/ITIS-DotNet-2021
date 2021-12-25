using System;
using System.Collections.Generic;
using System.Linq;
using WebAppHW13.Repository;

namespace WebAppHW13.Models;

public class ExpressionsCache
{
    private static readonly List<ComputedExpression> cache = new();

    public ComputedExpression GetOrSet(
        ComputedExpression expWithoutRes,
        Func<decimal> resultBuilder)
    {
        try
        {
            lock (cache)
            {
                return cache.First(expression =>
                    expression.V1 == expWithoutRes.V1 &&
                    expression.V2 == expWithoutRes.V2 &&
                    expression.Op == expWithoutRes.Op);
            }
        }
        catch
        {
            expWithoutRes.Res = resultBuilder();
            lock (cache)
            {
                cache.Add(expWithoutRes);
            }

            return expWithoutRes;
        }
    }
}