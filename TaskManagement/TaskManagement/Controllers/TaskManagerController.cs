using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Timers;
using TaskManagement.Common.Helper;
using TaskManagement.Manager.Manager;
using TaskManagement.Modal;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class TaskManagerController : ControllerBase
    {
        private readonly ITaskManager _taskmanager;
        public TaskManagerController(ITaskManager taskmanager)
        { 
            _taskmanager = taskmanager;
        }

        [HttpPost]

        public async Task<ApiResponse> AddEditTask(TaskManagementDto task) 
        {
            ApiResponse response = new ApiResponse();
            try
            {
                    var result = await _taskmanager.AddEditTaskAsync(task).ConfigureAwait(false);
                    response.Success = result.ErrorCode == 200 ? true : false;
                    response.Errorcode = result.ErrorCode;
                    response.Message = result.ErrorMessage;
                            
            }
            catch (Exception ex) 
            { 
                response.Success=false;
                response.Errorcode = 204;
                response.Message = ex.Message;

            }
            return response;
            
        }


        [HttpGet]
        public async Task<ApiResponse<TaskManagementDto>> GetAllTasksAsync(int Empid)
        {
            ApiResponse<TaskManagementDto> result = new ApiResponse<TaskManagementDto>();
            try
            {
                result.Data = await _taskmanager.GetAllTasksAsync(Empid).ConfigureAwait(false);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message; // Log the exception message
            }
            return result;
        }

        [HttpDelete]
        public async Task<ApiResponse> DeleteTaskAsync(int taskId)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var result = await _taskmanager.DeleteTaskAsync(taskId).ConfigureAwait(false);
                response.Success = result.ErrorCode == 200;
                response.Errorcode = result.ErrorCode;
                response.Message = result.ErrorMessage;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errorcode = 500;
                response.Message = $"An error occurred: {ex.Message}";
            }
            return response;
        }
        [HttpGet]
        public async Task<ApiResponse<EmployeeDto>> GetEmployeeHierarchyAsync(int EmployeeId) 
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            try
            {
                result.Data = await _taskmanager.GetEmployeeHierarchyAsync(EmployeeId).ConfigureAwait(false);
                result.Success = true;
                result.Errorcode = 200;

            }
            catch (Exception ex)
            { 
                result.Success = false;
                result.Errorcode = 500;
                result.Message = ex.Message;
            }
            return result;  
        }

        [HttpGet]
        public async Task<ApiPostResponse<TaskManagementDto>> GetTaskByIdAsync(int taskind)
        {
            ApiPostResponse<TaskManagementDto> result = new ApiPostResponse<TaskManagementDto>();
            try
            {
                result.Data = await _taskmanager.GetTaskByIdAsync(taskind).ConfigureAwait(false);
                result.Success = true;
                result.Message = "data Featched succefully";
                result.Errorcode = 200;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Errorcode = 500;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
