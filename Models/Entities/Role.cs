using System;
using System.Collections.Generic;

namespace _25._10.Models.Entities.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public static Role[] SeedData => new[]
    {
        new Role { RoleId = 1, RoleName = "Admin" },
        new Role { RoleId = 2, RoleName = "Mentor" },
        new Role { RoleId = 3, RoleName = "Student" }
    };
}