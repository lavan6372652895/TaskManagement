using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Modal;
using TaskManagement.Repository.Repo;

namespace TaskManagement.Manager.Manager
{
    public class Loginmanager : ILoginmanager
    {
        private readonly ILogin _repo;
        public Loginmanager(ILogin repo) 
        {
            _repo = repo;
        }
        public async Task<EmpLoginResponses> EmpLoginAsync(LoginDto login)
        {
            EmpLoginResponses emp =new EmpLoginResponses();
            //EmployeeDto empDto = new EmployeeDto();
            try
            {
                var responces = await _repo.EmpLoginAsync(login).ConfigureAwait(false);
                emp.employee = responces.employee;
                emp.modal = responces.modal;
            }
            catch (Exception ex) 
            {
                emp.modal.ErrorCode = 204;
                emp.modal.ErrorMessage = ex.Message;
            }
            return emp;
        }
    }
}
