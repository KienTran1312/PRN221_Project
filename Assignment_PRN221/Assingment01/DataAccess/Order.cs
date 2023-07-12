using System;
using System.Collections.Generic;

namespace Assingment01.DataAccess;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public string? Freight { get; set; }

    public string? ShipAdress { get; set; }

    public decimal? TotalMoney { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
