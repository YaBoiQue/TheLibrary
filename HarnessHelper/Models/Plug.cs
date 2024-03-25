using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Plug
{
    public int PlugId { get; set; }

    public int? DeviceId { get; set; }

    public string Name { get; set; } = null!;

    public int? NumPinHoles { get; set; }

    public string? Description { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Aspnetuser? User { get; set; }

    public virtual Device? Device { get; set; }

    public virtual ICollection<Pin> Pins { get; set; } = new List<Pin>();
}
