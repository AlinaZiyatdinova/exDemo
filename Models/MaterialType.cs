using System;
using System.Collections.Generic;

namespace WpfDemoZiaytdinova.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Percent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
