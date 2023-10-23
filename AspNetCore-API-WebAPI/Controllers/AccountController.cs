using AspNetCore_API_Entity.DTOs;
using AspNetCore_API_Entity.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            //if (user.Token != null)
            //{
            //    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //    var token = handler.ReadJwtToken(user.Token);
            //    var clamsIdentity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
            //    var autoProps = new AuthenticationProperties()
            //    {
            //        ExpiresUtc = user.ExpireDate,
            //        IsPersistent = true,
            //    };
            //    try
            //    {
            //        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(clamsIdentity), autoProps);
            //    }
            //    catch (Exception ex)
            //    {
            //        var mesage = ex.Message;
            //        throw;
            //    }
               

            //}

            if (user.Token == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
