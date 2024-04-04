using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICatogoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    }
}
