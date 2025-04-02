using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;
using TaskManagement.Modal;

namespace TaskManagement.Repository.Repo
{
    public interface ITaskRepo
    {
        Task<ErrorModal> AddEditTaskAsync(TaskManagementDto task);
        Task<List<TaskManagementDto>> GetAllTasksAsync(int Empid);
    }
}
