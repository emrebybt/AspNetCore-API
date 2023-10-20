using AspNetCore_API_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Entity.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
        void Add(EmployeeDto entity);
        void Update(EmployeeDto entity);
        void Delete(EmployeeDto entity);

    }
}
