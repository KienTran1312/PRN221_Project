using System;
using System.Collections.Generic;

namespace Assingment01.DataAccess;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? Password { get; set; }

    public string? ContactName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
