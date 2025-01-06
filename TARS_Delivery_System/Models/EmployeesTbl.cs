using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class EmployeesTbl
{
    public int EmployeeId { get; set; }

    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public int BranchId { get; set; }

    public virtual BranchTbl Branch { get; set; } = null!;

    public virtual UserTbl User { get; set; } = null!;
}
