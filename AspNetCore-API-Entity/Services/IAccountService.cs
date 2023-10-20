using AspNetCore_API_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Entity.Services
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterDto model);
        Task<UserDto> Login(LoginDto model);
    }
}
