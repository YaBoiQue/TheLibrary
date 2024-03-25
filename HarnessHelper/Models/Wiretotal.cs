using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Wiretotal
{
    public int WireId { get; set; }

    public string ColorCode { get; set; } = null!;

    public string? Gauge { get; set; }

    public string? Description { get; set; }

    public decimal? NumPlugs { get; set; }
}
