using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Plugtotal
{
    public int PlugId { get; set; }

    public int? DeviceId { get; set; }

    public string Name { get; set; } = null!;

    public int? NumPinHoles { get; set; }

    public string? Description { get; set; }

    public decimal? NumWires { get; set; }
}
