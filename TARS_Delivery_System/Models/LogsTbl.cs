using System;
using System.Collections.Generic;

namespace TARS_Delivery_System.Models;

public partial class LogsTbl
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime LogDate { get; set; }

    public string IpAdress { get; set; } = null!;

    public virtual UserTbl User { get; set; } = null!;
}
