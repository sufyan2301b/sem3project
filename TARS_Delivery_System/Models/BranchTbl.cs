using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class BranchTbl
{
    public int BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? PinCode { get; set; }

    public virtual ICollection<DeliverablesTbl> DeliverablesTbls { get; set; } = new List<DeliverablesTbl>();

    public virtual ICollection<EmployeesTbl> EmployeesTbls { get; set; } = new List<EmployeesTbl>();
}
