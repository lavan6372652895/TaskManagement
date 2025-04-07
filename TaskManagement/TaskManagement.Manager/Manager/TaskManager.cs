using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;
using TaskManagement.Modal;
using TaskManagement.Repository.Repo;

namespace TaskManagement.Manager.Manager
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepo _taskRepo;
        public TaskManager(ITaskRepo taskrepo) 
        { 
            _taskRepo = taskrepo;
        }

        public async Task<ErrorModal> AddEditTaskAsync(TaskManagementDto task)
        {
            ErrorModal errorModal = new ErrorModal();
            try
            {
                errorModal = await _taskRepo.AddEditTaskAsync(task).ConfigureAwait(false);
            }
            catch (Exception ex) 
            { 
                errorModal.ErrorMessage = ex.Message;
                errorModal.ErrorCode = 201;
            }
            return errorModal;
        }

        public async Task<ErrorModal> DeleteTaskAsync(int TaskId)
        {
            ErrorModal errorModal = new ErrorModal();
            try
            {
                errorModal = await _taskRepo.DeleteTaskAsync(TaskId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                errorModal.ErrorMessage = ex.Message;
                errorModal.ErrorCode = 500;
            }
            return errorModal;
        }


        public async Task<List<TaskManagementDto>> GetAllTasksAsync(int Empid)
        {
            List<TaskManagementDto> result = new List<TaskManagementDto>();
            try
            {
                result = await _taskRepo.GetAllTasksAsync(Empid);
            }
            catch (Exception ex) 
            { 
            throw(ex);
            }
            return result;
        }

        public Task<List<EmployeeDto>> GetEmployeeHierarchyAsync(int EmployeeId)
        {
           return _taskRepo.GetEmployeeHierarchyAsync(EmployeeId);
        }

        public async Task<TaskManagementDto> GetTaskByIdAsync(int Taskid)
        {
            try
            {
                return await _taskRepo.GetTaskByIdAsync(Taskid).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
