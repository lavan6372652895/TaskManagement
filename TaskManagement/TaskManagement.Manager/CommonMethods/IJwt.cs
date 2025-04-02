using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Modal;

namespace TaskManagement.Manager.CommonMethods
{
    public interface IJwt
    {
        string GenerateTokenAsync(EmployeeDto emp);
    }
}
