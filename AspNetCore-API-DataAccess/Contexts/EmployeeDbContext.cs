using AspNetCore_API_DataAccess.Identity;
using AspNetCore_API_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_DataAccess.Contexts
{
    public class EmployeeDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
