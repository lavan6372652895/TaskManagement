using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Helper;
using TaskManagement.Modal;
using TaskManagement.Repository.DbModal;

namespace TaskManagement.Repository.Repo
{
    public class LoginRepo: ILogin
    {
        private IMapper _mapper;
        private readonly TaskmanagementContext _context;
        public LoginRepo(TaskmanagementContext context,IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpLoginResponses> EmpLoginAsync(LoginDto login)
        {
            EmpLoginResponses response = new EmpLoginResponses()
            {
                employee=new EmployeeDto(),
                modal= new ErrorModal()
            };
            try
            {
                // Attempt to find the user by username
                var user = await _context.UserAuthontications.AsNoTracking()
                                          .FirstOrDefaultAsync(x => x.Username == login.UserName)
                                          .ConfigureAwait(false);

                  // If the username is found, validate the password
                if (user != null)
                {
                    // If passwords match (ensure password is hashed and compared securely)
                    if (user.Password == login.Password) 
                    {
                        response.modal.ErrorCode = 200;
                        response.modal.ErrorMessage = "Login successful!";
                       var data = await _context.Employees.SingleAsync(x => x.Email==login.UserName).ConfigureAwait(false);
                        response.employee= _mapper.Map<Employee,EmployeeDto>(data);
                      


                    }
                    else
                    {
                        response.modal.ErrorCode = 401;
                        response.modal.ErrorMessage = "Invalid password.";
                    }
                }
                else
                {
                    response.modal.ErrorCode = 204;
                    response.modal.ErrorMessage = "User not found.";
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                // You can use a logger or log the error to a file or console
                response.modal.ErrorCode = 204;
                response.modal.ErrorMessage = "An error occurred during the login process.";
            }

            return response;
        }

    }
}
