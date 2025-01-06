using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class DeliverablesTbl
{
    public int DeliverableId { get; set; }

    public int UserId { get; set; }

    public int BranchId { get; set; }

    public string DeliveryType { get; set; } = null!;

    public decimal Weight { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DeliveryDate { get; set; }

    public DateTime SendDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public decimal Charge { get; set; }

    public string SenderName { get; set; } = null!;

    public string SenderContact { get; set; } = null!;

    public string ReceiverName { get; set; } = null!;

    public string ReceiverContact { get; set; } = null!;

    public string ReceiverAddress { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public int TrackingId { get; set; }

    public virtual BranchTbl Branch { get; set; } = null!;

    public virtual ICollection<PaymentTbl> PaymentTbls { get; set; } = new List<PaymentTbl>();

    public virtual ICollection<TrackingTbl> TrackingTbls { get; set; } = new List<TrackingTbl>();

    public virtual UserTbl User { get; set; } = null!;
}
