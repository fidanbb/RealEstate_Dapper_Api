using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }


        public async Task CreateServiceAsync(CreateServiceDto request)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) " +
                "values (@name,@status)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@name", request.ServiceName); 
            parametrs.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            string query = "Delete from Service where  ServiceID =@serviceID";

            var parametrs = new DynamicParameters();
            parametrs.Add("@serviceID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetServiceAsync(int id)
        {
            string query = "Select * from Service Where ServiceID = @serviceID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@serviceID", id);

            using (var connection = _context.CreateConnection())
            {

                var value = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parametrs);

                return value;
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto request)
        {
            string query = "Update Service Set ServiceName=@name,ServiceStatus=@status " +
                "where ServiceID=@serviceID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@name", request.ServiceName);
          
            parametrs.Add("@status", true);
            parametrs.Add("@serviceID", request.ServiceID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
