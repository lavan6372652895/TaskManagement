using System;
using System.Collections.Generic;

namespace TaskManagement.Repository.DbModal;

public partial class TaskManagement
{
    public int TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDetails { get; set; }

    public string? Comments { get; set; }

    public int? TaskStatus { get; set; }

    public int? TaskFor { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedTime { get; set; }

    public virtual Employee? AssignedByNavigation { get; set; }

    public virtual Employee? TaskForNavigation { get; set; }

    public virtual Taskstatus? TaskStatusNavigation { get; set; }
}
