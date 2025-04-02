using System;
using System.Collections.Generic;

namespace TaskManagement.Repository.DbModal;

public partial class Taskstatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<TaskManagement> TaskManagements { get; set; } = new List<TaskManagement>();
}
