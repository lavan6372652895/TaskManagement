using AutoMapper;
using TaskManagement.Modal;
using TaskManagement.Repository.DbModal;

namespace TaskManagement
{
    public class DtoProfile: Profile
    {
        public DtoProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<TaskManagement.Repository.DbModal.TaskManagement, TaskManagementDto>().ReverseMap();
        
        }
    }
}
