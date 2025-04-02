using System;
using System.Collections.Generic;

namespace TaskManagement.Repository.DbModal;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
