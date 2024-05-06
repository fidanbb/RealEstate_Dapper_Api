
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task CreatePopularLocationAsync(CreatePopularLocationDto request);

        Task DeletePopularLocationAsync(int id);

        Task UpdatePopularLocationAsync(UpdatePopularLocationDto request);

        Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id);
    }
}
