using AspNetCore_API_DataAccess.Identity;
using AspNetCore_API_Entity.DTOs;
using AspNetCore_API_Entity.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<string> CreateUserAsync(RegisterDto model)
        {
            string message = string.Empty;
            var user = new AppUser()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.Phone,
            };
            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;


        }

        public async Task<UserDto> Login(LoginDto model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByNameAsync(model.UserName);
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                var token = _authService.GenerateToken(await _userManager.GetRolesAsync(user));
                UserDto user1 = new UserDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    UserName = model.UserName,
                    Token = token,
                    ExpireDate = DateTime.Now.AddDays(1)
                };
                return user1;
            }
            return new UserDto();
        }
    }
}
