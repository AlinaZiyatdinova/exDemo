using System;
using System.Collections.Generic;

namespace WpfDemoZiaytdinova.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PartnerId { get; set; }

    public string? Count { get; set; }

    public string? DateSale { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Product? Product { get; set; }
}
