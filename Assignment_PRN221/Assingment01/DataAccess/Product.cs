using System;
using System.Collections.Generic;

namespace Assingment01.DataAccess;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public decimal? UnitPrice { get; set; }

    public string? ProductImage { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
