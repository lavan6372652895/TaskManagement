using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;

namespace TaskManagement.Modal
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }

        public string? EmpName { get; set; }

        public string? Email { get; set; }

        public int? Roles { get; set; }

        public int? ManagerId { get; set; }

        public bool? IsActive { get; set; }

    }
    public class LoginDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }

    public class EmpLoginResponses
    {
        public ErrorModal modal { get; set; }
        public EmployeeDto? employee { get; set; }
    }

    public class EmpTokenResponses : EmpLoginResponses
    {
        public string token { get; set; } = string.Empty;


    }
}
