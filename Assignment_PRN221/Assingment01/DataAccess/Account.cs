using System;
using System.Collections.Generic;

namespace Assingment01.DataAccess;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Type { get; set; }
}
