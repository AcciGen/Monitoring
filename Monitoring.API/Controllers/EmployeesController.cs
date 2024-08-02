using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Monitoring.Application.UseCases.ConsumptionCases.Commands;
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
                UserName = model.FullName.Trim().Replace("А", "A").Replace("Б", "B").Replace("В", "V").Replace("Г", "G")
            .Replace("Д", "D").Replace("Е", "E").Replace("Ё", "Yo").Replace("Ж", "Zh")
            .Replace("З", "Z").Replace("И", "I").Replace("Й", "Y").Replace("К", "K")
            .Replace("Л", "L").Replace("М", "M").Replace("Н", "N").Replace("О", "O")
            .Replace("П", "P").Replace("Р", "R").Replace("С", "S").Replace("Т", "T")
            .Replace("У", "U").Replace("Ф", "F").Replace("Х", "Kh").Replace("Ц", "Ts")
            .Replace("Ч", "Ch").Replace("Ш", "Sh").Replace("Щ", "Shch").Replace("Ъ", "")
            .Replace("Ы", "Y").Replace("Ь", "").Replace("Э", "E").Replace("Ю", "Yu")
            .Replace("Я", "Ya")
            // Lowercase letters
            .Replace("а", "a").Replace("б", "b").Replace("в", "v").Replace("г", "g")
            .Replace("д", "d").Replace("е", "e").Replace("ё", "yo").Replace("ж", "zh")
            .Replace("з", "z").Replace("и", "i").Replace("й", "y").Replace("к", "k")
            .Replace("л", "l").Replace("м", "m").Replace("н", "n").Replace("о", "o")
            .Replace("п", "p").Replace("р", "r").Replace("с", "s").Replace("т", "t")
            .Replace("у", "u").Replace("ф", "f").Replace("х", "kh").Replace("ц", "ts")
            .Replace("ч", "ch").Replace("ш", "sh").Replace("щ", "shch").Replace("ъ", "")
            .Replace("ы", "y").Replace("ь", "").Replace("э", "e").Replace("ю", "yu")
            .Replace("я", "ya"),
                PhoneNumber = model.PhoneNumber,
                Position = model.Position,
                Salary = model.Salary,
                GivenSalary = model.GivenSalary,
                SalaryDate = model.SalaryDate,
                EmploymentDate = model.EmploymentDate,
                Percent = model.Percent,
                RemainedSalary = (model.Salary ?? 0) - (model.GivenSalary ?? 0)
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
        public async Task<ResponseModel> Update(EmployeeIdDTO model)
        {
            var employee = await _userManager.FindByIdAsync(model.Id.ToString());

            if (employee != null)
            {
                employee.FullName = model.FullName;
                employee.UserName = model.FullName.Trim().Replace("А", "A").Replace("Б", "B").Replace("В", "V").Replace("Г", "G")
            .Replace("Д", "D").Replace("Е", "E").Replace("Ё", "Yo").Replace("Ж", "Zh")
            .Replace("З", "Z").Replace("И", "I").Replace("Й", "Y").Replace("К", "K")
            .Replace("Л", "L").Replace("М", "M").Replace("Н", "N").Replace("О", "O")
            .Replace("П", "P").Replace("Р", "R").Replace("С", "S").Replace("Т", "T")
            .Replace("У", "U").Replace("Ф", "F").Replace("Х", "Kh").Replace("Ц", "Ts")
            .Replace("Ч", "Ch").Replace("Ш", "Sh").Replace("Щ", "Shch").Replace("Ъ", "")
            .Replace("Ы", "Y").Replace("Ь", "").Replace("Э", "E").Replace("Ю", "Yu")
            .Replace("Я", "Ya")
            // Lowercase letters
            .Replace("а", "a").Replace("б", "b").Replace("в", "v").Replace("г", "g")
            .Replace("д", "d").Replace("е", "e").Replace("ё", "yo").Replace("ж", "zh")
            .Replace("з", "z").Replace("и", "i").Replace("й", "y").Replace("к", "k")
            .Replace("л", "l").Replace("м", "m").Replace("н", "n").Replace("о", "o")
            .Replace("п", "p").Replace("р", "r").Replace("с", "s").Replace("т", "t")
            .Replace("у", "u").Replace("ф", "f").Replace("х", "kh").Replace("ц", "ts")
            .Replace("ч", "ch").Replace("ш", "sh").Replace("щ", "shch").Replace("ъ", "")
            .Replace("ы", "y").Replace("ь", "").Replace("э", "e").Replace("ю", "yu")
            .Replace("я", "ya");
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
                employee.RemainedSalary = (model.Salary ?? 0) - (model.GivenSalary ?? 0) - (model.Fine ?? 0);

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
        public async Task<ResponseModel> Delete([FromBody] DeleteConsumptionCommand model)
        {
            var employee = await _userManager.FindByIdAsync(model.Id.ToString());

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
