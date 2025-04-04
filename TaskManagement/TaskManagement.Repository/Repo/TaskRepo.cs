using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;
using TaskManagement.Modal;
using TaskManagement.Repository.DbModal;

namespace TaskManagement.Repository.Repo
{
    public class TaskRepo:ITaskRepo
    {
        private readonly TaskmanagementContext _context;
        private  readonly IMapper _mapper;
        public TaskRepo(TaskmanagementContext context,IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<ErrorModal> AddEditTaskAsync(TaskManagementDto task)
        {
            ErrorModal modal = new ErrorModal();
            try
            {
                int? managerid = task.AssignedBy;
                int[] emp = CheckHierarchy(managerid);

                if (emp.Any(x => x == task.TaskFor))
                {
                    var data = _mapper.Map<TaskManagementDto, TaskManagement.Repository.DbModal.TaskManagement>(task);

                    // Custom AddOrUpdate logic (since EF Core doesn't support it)
                    var existingTask = await _context.TaskManagements.FindAsync(task.TaskId);
                    if (existingTask != null)
                    {
                        _context.Entry(existingTask).CurrentValues.SetValues(data);
                        modal.ErrorMessage = "Task is Updated Successfully";
                    }
                    else
                    {
                        await _context.TaskManagements.AddAsync(data);
                        modal.ErrorMessage = "Task Is Added Successfully";
                    }

                    await _context.SaveChangesAsync(); // Ensure async save
                    modal.ErrorCode = 200;
                }
                else
                {
                    modal.ErrorMessage = "Please select a proper employee. He is not in your team.";
                    modal.ErrorCode = 204;
                }
            }
            catch (Exception ex)
            {
                modal.ErrorMessage = ex.Message;
                modal.ErrorCode = 201;
            }
            return modal;
        }

        public async Task<List<TaskManagementDto>> GetAllTasksAsync(int Empid)
        {
            List<TaskManagementDto> data = new List<TaskManagementDto>();
            try
            {
                string roleNames = (from emp in  _context.Employees
                                 join role in _context.Roles on
                                 emp.Roles equals role.Id where emp.EmpId ==Empid
                                 select role.RoleName).AsNoTracking().FirstOrDefault() ?? string.Empty;

                if (roleNames.Equals("Developer"))
                {
                    var result = await _context.TaskManagements.Where(x=>x.TaskFor==Empid).ToListAsync().ConfigureAwait(false);
                    data =_mapper.Map<List<TaskManagementDto>>(result);
                }
                else
                {
                    var result = await _context.TaskManagements.Where(x=>x.AssignedBy==Empid).ToListAsync().ConfigureAwait(false);
                    data = _mapper.Map<List<TaskManagementDto>>(result);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        private int[] CheckHierarchy(int? managerid)
        {
            int[] AssignedBy = _context.Employees.Where(x => x.ManagerId == managerid).Select(e => e.EmpId).ToArray();
            return AssignedBy;
        }

        public async Task<ErrorModal> DeleteTaskAsync(int taskId)
        {
            ErrorModal modal = new ErrorModal();
            try
            {
                var task = await _context.TaskManagements.FindAsync(taskId);
                if (task != null)
                {
                    _context.TaskManagements.Remove(task);
                    await _context.SaveChangesAsync();

                    modal.ErrorCode = 200;
                    modal.ErrorMessage = "Task deleted successfully.";
                }
                else
                {
                    modal.ErrorCode = 204;
                    modal.ErrorMessage = "Task not found.";
                }
            }
            catch (Exception ex)
            {
                modal.ErrorCode = 500;
                modal.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return modal;
        }


    }
}
