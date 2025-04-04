using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;
using TaskManagement.Modal;

namespace TaskManagement.Manager.Manager
{
    public interface ITaskManager
    {
        Task<ErrorModal> AddEditTaskAsync(TaskManagementDto task);
        Task<List<TaskManagementDto>> GetAllTasksAsync(int Empid);
        Task<ErrorModal> DeleteTaskAsync(int TaskId);
    }
}
