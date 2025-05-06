using System;
using System.Collections.Generic;

namespace WpfDemoZiaytdinova.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Art { get; set; }

    public string? MinPrice { get; set; }

    public int? ProductTypeId { get; set; }

    public int? MaterialTypeId { get; set; }

    public virtual MaterialType? MaterialType { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType? ProductType { get; set; }
}
