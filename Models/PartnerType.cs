using System;
using System.Collections.Generic;

namespace WpfDemoZiaytdinova.Models;

public partial class PartnerType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
