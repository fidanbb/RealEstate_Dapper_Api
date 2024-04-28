using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task CreateEmployeeAsync(CreateEmployeeDto request);

        Task DeleteEmployeeAsync(int id);

        Task UpdateEmployeeAsync(UpdateEmployeeDto request);

        Task<GetByIdEmployeeDto> GetEmployeeAsync(int id);
    }
}
