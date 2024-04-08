using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        Task CreateWoWeAreDetailAsync(CreateWhoWeAreDetailDto request);

        Task DeleteWhoWeAreDetailAsync(int id);

        Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto request);

        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id);
    }
}
