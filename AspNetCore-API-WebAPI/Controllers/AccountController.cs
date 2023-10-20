using AspNetCore_API_Entity.DTOs;
using AspNetCore_API_Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_API_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            string msg = await _accountService.CreateUserAsync(model);
            return Created(string.Empty, msg);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _accountService.Login(model);
            if (user.Token == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
