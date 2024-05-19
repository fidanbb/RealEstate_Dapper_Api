using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task ActivateDealOfTheDayAsync(int id);
        Task DeactivateDealOfTheDayAsync(int id);

        Task<List<ResultLast5ProductWithCategoryDto>> GetLastFiveProductsAsync();
        Task<List<ResultLast5ProductWithCategoryDto>> GetLastFiveProductsByEmployeeAsync(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetActiveProductAdvertListByEmployeeAsync(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetPassiveProductAdvertListByEmployeeAsync(int id);
    }
}
