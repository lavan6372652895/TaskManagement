using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Modal
{
    public class TaskManagementDto
    {
        public int TaskId { get; set; }
        [Required]
        public string? TaskName { get; set; }
        [Required]
        public string? TaskDetails { get; set; }

        public string? Comments { get; set; }

        public int? TaskStatus { get; set; }
        [Required]
        public int? TaskFor { get; set; }
        [Required]
        public int? AssignedBy { get; set; }

        public DateTime? AssignedTime { get; set; }
    }
}
