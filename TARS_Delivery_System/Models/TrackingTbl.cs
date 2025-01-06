using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class TrackingTbl
{
    public int TrackingId { get; set; }

    public int DeliverableId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public byte[] Location { get; set; } = null!;

    public string ActionTaken { get; set; } = null!;

    public int UpdatedBy { get; set; }

    public virtual DeliverablesTbl Deliverable { get; set; } = null!;
}
