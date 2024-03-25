using System;
using System.Collections.Generic;

namespace HarnessHelper.Models;

public partial class Color
{
    /// <summary>
    /// Solid colors consist of
    /// Black = BK
    /// Brown = BN
    /// Red = RD
    /// Orange = OG
    /// Yellow = YE
    /// Green = GN
    /// Blue = BU
    /// Violent = VT
    /// Grey = GY
    /// White = WH
    /// Pink = PK
    /// Gold = GD
    /// Turquoise = TQ
    /// Silver = SR
    /// Green - Yellow = GNYE
    /// 
    /// For striped wires use Solid/Stripe
    /// </summary>
    public string ColorCode { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public byte[]? SolidValue { get; set; }

    public byte[]? StripeValue { get; set; }
}
