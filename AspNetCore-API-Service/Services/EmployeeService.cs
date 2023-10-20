using AspNetCore_API_Entity.DTOs;
using AspNetCore_API_Entity.Entities;
using AspNetCore_API_Entity.Services;
using AspNetCore_API_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWorks _uow;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWorks uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            var list = await _uow.GetRepository<Employee>().GetAllAsync();
            return _mapper.Map<List<EmployeeDto>>(list);
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _uow.GetRepository<Employee>().GetById(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public void Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
