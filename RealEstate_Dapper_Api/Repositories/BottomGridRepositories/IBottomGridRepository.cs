using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto request);

        Task DeleteBottomGridAsync(int id);

        Task UpdateBottomGridAsync(UpdateBottomGridDto request);

        Task<GetByIdBottomGridDto> GetBottomGridAsync(int id);
    }
}
