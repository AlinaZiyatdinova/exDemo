using System;
using System.Collections.Generic;

namespace WpfDemoZiaytdinova.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string? ProductTypeName { get; set; }

    public string? Coefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
