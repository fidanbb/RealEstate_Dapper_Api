
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateCServiceAsync(CreateServiceDto request);

        Task DeleteServiceAsync(int id);

        Task UpdateServiceAsync(UpdateServiceDto request);

        Task<GetByIdServiceDto> GetServiceAsync(int id);
    }
}
