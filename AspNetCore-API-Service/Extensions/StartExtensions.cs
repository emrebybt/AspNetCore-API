using AspNetCore_API_DataAccess.Contexts;
using AspNetCore_API_DataAccess.Identity;
using AspNetCore_API_DataAccess.Repositories;
using AspNetCore_API_DataAccess.UnitOfWorks;
using AspNetCore_API_Entity.Repositories;
using AspNetCore_API_Entity.Services;
using AspNetCore_API_Entity.UnitOfWorks;
using AspNetCore_API_Service.Mapping;
using AspNetCore_API_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCore_API_Service.Extensions
{
    public static class StartExtensions
    {
        public static void AddExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var JwtDefaults = configuration.GetSection("JwtDefaults");
            var secretKey = JwtDefaults["secretKey"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme
            ).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtDefaults["ValidIssuer"],
                    ValidAudience = JwtDefaults["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();



            services.AddIdentity<AppUser, AppRole>(
            opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
            }
            ).AddEntityFrameworkStores<EmployeeDbContext>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthService, AuthService>();


            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
