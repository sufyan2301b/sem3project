using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class PaymentTbl
{
    public int PaymentId { get; set; }

    public int DeliverableId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public virtual DeliverablesTbl Deliverable { get; set; } = null!;
}
