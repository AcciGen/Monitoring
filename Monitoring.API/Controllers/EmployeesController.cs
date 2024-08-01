using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;

        public EmployeesController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(EmployeeDTO model)
        {
            var employee = new Employee()
            {
                FullName = model.FullName,
                UserName = model.FullName.Split(' ')[0],
                PhoneNumber = model.PhoneNumber,
                Position = model.Position,
                Salary = model.Salary,
                GivenSalary = model.GivenSalary,
                SalaryDate = model.SalaryDate,
                EmploymentDate = model.EmploymentDate,
                Percent = model.Percent,

                Fine = model.Fine,
                Description = model.Description,
                FineDate = model.FineDate,
                RemainedSalary = model.RemainedSalary
            };

            var result = await _userManager.CreateAsync(employee);

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(employee, "Employee");

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "Employee was successfully added!",
                StatusCode = 201
            };
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(Guid id)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new Exception();

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(Guid id, EmployeeDTO model)
        {
            var employee = await _userManager.FindByIdAsync(id.ToString());

            if (employee != null)
            {
                employee.FullName = model.FullName;
                employee.UserName = model.FullName.Split(' ')[0];
                employee.PhoneNumber = model.PhoneNumber;
                employee.Position = model.Position;
                employee.Salary = model.Salary;
                employee.GivenSalary = model.GivenSalary;
                employee.SalaryDate = model.SalaryDate;
                employee.EmploymentDate = model.EmploymentDate;
                employee.Percent = model.Percent;

                employee.Fine = model.Fine;
                employee.Description = model.Description;
                employee.FineDate = model.FineDate;
                employee.RemainedSalary = model.RemainedSalary;

                var result = await _userManager.UpdateAsync(employee);

                return new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Employee was successfully updated!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Employee was not found!",
                StatusCode = 404
            };
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(Guid id)
        {
            var employee = await _userManager.FindByIdAsync(id.ToString());

            if (employee != null)
            {
                await _userManager.DeleteAsync(employee);

                return new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Employee was successfully removed!",
                    StatusCode = 201
                };
            }

            return new ResponseModel
            {
                Message = "Employee was not found!",
                StatusCode = 404
            };
        }
    }
}
