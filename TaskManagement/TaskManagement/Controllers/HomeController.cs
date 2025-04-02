using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Common.Helper;
using TaskManagement.Manager.CommonMethods;
using TaskManagement.Manager.Manager;
using TaskManagement.Modal;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class HomeController : ControllerBase
    {
        private readonly ILoginmanager _manager;
        private readonly IJwt _jwt;
        public HomeController(ILoginmanager manager,IJwt jwt)
        { 
            _manager = manager;
            _jwt = jwt;
        }

        [HttpPost]
        public async Task<ApiPostResponse<EmpTokenResponses>> EmployeeLoginAsync(LoginDto login)
        {
            ApiPostResponse<EmpTokenResponses> responces = new ApiPostResponse<EmpTokenResponses>();
            try
            {
               var userlogin = await _manager.EmpLoginAsync(login).ConfigureAwait(false);
                if (userlogin.modal.ErrorCode == 200)
                {
                   
                  string token = _jwt.GenerateTokenAsync(userlogin.employee).ToString();
                    EmpTokenResponses emp = new EmpTokenResponses
                    {
                      employee=userlogin.employee,
                      token=token
                    };
                    responces.Errorcode = userlogin.modal.ErrorCode;
                    responces.Message = userlogin.modal.ErrorMessage;
                    responces.Success = true;
                    responces.Data = emp;
                }
            }
            catch (Exception ex)
            {
                responces.Success = false;
                responces.Errorcode = 204;
                responces.Message = ex.Message;
            }
            return responces;
        }
    }
}
