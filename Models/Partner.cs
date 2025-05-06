using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfDemoZiaytdinova.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int? PartnerTypeId { get; set; }

    public string? Name { get; set; }

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public string? Raiting { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerType? PartnerType { get; set; }

    [NotMapped]
    public decimal? TotalSales { get; set; }
    [NotMapped]
    public decimal? Discount { get; set; }
}
