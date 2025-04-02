using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Modal;

namespace TaskManagement.Manager.Manager
{
    public interface ILoginmanager
    {
        Task<EmpLoginResponses> EmpLoginAsync(LoginDto login);
    }
}
