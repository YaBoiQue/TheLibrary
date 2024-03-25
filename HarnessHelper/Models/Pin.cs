using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Pin
{
    public int PinId { get; set; }

    public int PlugId { get; set; }

    public int WireId { get; set; }

    public int? Position { get; set; }

    public string? UserId { get; set; }

    public virtual Plug Plug { get; set; } = null!;

    public virtual Wire Wire { get; set; } = null!;
}
