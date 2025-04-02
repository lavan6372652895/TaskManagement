using System;
using System.Collections.Generic;

namespace TaskManagement.Repository.DbModal;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Email { get; set; }

    public int? Roles { get; set; }

    public int? ManagerId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Role? RolesNavigation { get; set; }

    public virtual ICollection<TaskManagement> TaskManagementAssignedByNavigations { get; set; } = new List<TaskManagement>();

    public virtual ICollection<TaskManagement> TaskManagementTaskForNavigations { get; set; } = new List<TaskManagement>();

    public virtual ICollection<UserAuthontication> UserAuthontications { get; set; } = new List<UserAuthontication>();
}
