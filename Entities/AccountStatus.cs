using System;
using System.Collections.Generic;

namespace _25._10.Entities;

public partial class AccountStatus
{
    public int AccountStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
