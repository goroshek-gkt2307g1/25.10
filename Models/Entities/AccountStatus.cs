using System;
using System.Collections.Generic;

namespace _25._10.Models.Entities.Entities;

public partial class AccountStatus
{
    public int AccountStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public static AccountStatus[] SeedData => new[]
    {
        new AccountStatus { AccountStatusId = 1, StatusName = "Active" },
        new AccountStatus { AccountStatusId = 2, StatusName = "Inactive" }
    };
}