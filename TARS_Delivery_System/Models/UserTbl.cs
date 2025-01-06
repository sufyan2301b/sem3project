using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class UserTbl
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public virtual ICollection<DeliverablesTbl> DeliverablesTbls { get; set; } = new List<DeliverablesTbl>();

    public virtual ICollection<EmployeesTbl> EmployeesTbls { get; set; } = new List<EmployeesTbl>();

    public virtual ICollection<LogsTbl> LogsTbls { get; set; } = new List<LogsTbl>();
}
