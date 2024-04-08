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


        public Task CreateCServiceAsync(CreateServiceDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<GetByIdServiceDto> GetServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(UpdateServiceDto request)
        {
            throw new NotImplementedException();
        }
    }
}
