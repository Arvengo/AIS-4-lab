using System;
using System.Collections.Generic;

namespace Server;

public partial class Optic
{
    public int Id { get; set; }

    public string LeftLens { get; set; }

    public string RightLens { get; set; }

    public double Price { get; set; }

    public string Coating { get; set; }

    public string FrameMaterial { get; set; }

    public bool InInstallments { get; set; }
}
