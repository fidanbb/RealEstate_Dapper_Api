using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployeeAsync(CreateEmployeeDto request)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) " +
                "values (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@name", request.Name);
            parametrs.Add("@title", request.Title);
            parametrs.Add("@mail", request.Mail);
            parametrs.Add("@phoneNumber", request.PhoneNumber);
            parametrs.Add("@imageUrl", request.ImageUrl);
            parametrs.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "Delete from Employee where  EmployeeID =@employeeID";

            var parametrs = new DynamicParameters();
            parametrs.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployeeAsync(int id)
        {
            string query = "Select * from Employee Where EmployeeID = @employeeID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {

                var value = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parametrs);

                return value;
            }
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto request)
        {
            string query = "Update Employee Set Name=@name,Title=@title, Mail=@mail," +
                "PhoneNumber=@phoneNumber, ImageUrl=@imageUrl,Status=@status " +
                 "where employeeID=@employeeID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@name", request.Name);
            parametrs.Add("@title", request.Title);
            parametrs.Add("@mail", request.Mail);
            parametrs.Add("@phoneNumber", request.PhoneNumber);
            parametrs.Add("@imageUrl", request.ImageUrl);
            parametrs.Add("@status", true);
            parametrs.Add("@employeeID", request.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
