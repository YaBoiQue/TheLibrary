using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Devicetotal
{
    public int DeviceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? NumPlugSpots { get; set; }

    public decimal? NumPlugs { get; set; }

    public decimal? NumWires { get; set; }

    public decimal? NumDevices { get; set; }
}
