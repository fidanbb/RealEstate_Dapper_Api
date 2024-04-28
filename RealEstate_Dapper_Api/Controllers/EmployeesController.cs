using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController( IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]

        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto request)
        {
            await _employeeRepository.CreateEmployeeAsync(request);

            return Ok("Employee created successfully...");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployeeAsync(id);
            return Ok("Employee deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto request)
        {
            _employeeRepository.UpdateEmployeeAsync(request);

            return Ok("Employee updated successfully...");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await _employeeRepository.GetEmployeeAsync(id));
        }
    }
}
