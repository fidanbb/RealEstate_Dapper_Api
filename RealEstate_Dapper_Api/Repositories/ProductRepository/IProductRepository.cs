using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
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

        Task CreateProductAsync(CreateProductDto request);

        Task<GetProductByProductIdDto> GetProductByProductIdDtoAsync(int id);
        Task<GetProductDetailByIdDto> GetProductDetailByProductIdDtoAsync(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city);


        Task<List<ResultProductWithCategoryDto>> GetProductsByDealOfDayTrueWithCategoryAsync();

        Task<List<ResultLast3ProductWithCategoryDto>> GetLastThreeProductsAsync();
    }
}
