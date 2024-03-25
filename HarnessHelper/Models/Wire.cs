using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Wire
{
    public int WireId { get; set; }

    public string ColorCode { get; set; } = null!;

    public string? Gauge { get; set; }

    public string? Description { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ICollection<Pin> Pins { get; set; } = new List<Pin>();
}
