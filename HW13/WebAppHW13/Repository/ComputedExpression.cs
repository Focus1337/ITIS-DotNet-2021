﻿using System.ComponentModel.DataAnnotations.Schema;
using WebAppHW13.Models;

namespace WebAppHW13.Repository;

[Table($"{nameof(ComputedExpression)}s")]
// ReSharper disable once ClassNeverInstantiated.Global
public class ComputedExpression
{
    public decimal V1 { get; init; }
    public decimal V2 { get; init; }
    public Operation Op { get; init; }
    public decimal? Res { get; set; }
}