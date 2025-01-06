using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class ServiceChargesTbl
{
    public int ServiceChargeId { get; set; }

    public string ServiceType { get; set; } = null!;

    public decimal BaseCharge { get; set; }

    public decimal WeightFactor { get; set; }

    public decimal? DistanceFactor { get; set; }
}
