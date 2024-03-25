using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public string Name { get; set; } = null!;

    public int? NumPlugSpots { get; set; }

    public string? Description { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Aspnetuser? User { get; set; }

    public virtual ICollection<Plug> Plugs { get; set; } = new List<Plug>();
}
