using Azure.Core;
using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task ActivateDealOfTheDayAsync(int id)
        {
            string query = "Update Product Set DealOfTheDay=@dealOfTheDay " +
              "where ProductID=@productID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@dealOfTheDay", true);

            parametrs.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeactivateDealOfTheDayAsync(int id)
        {
            string query = "Update Product Set DealOfTheDay=@dealOfTheDay " +
             "where ProductID=@productID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@dealOfTheDay", false);

            parametrs.Add("@productID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";

            using (var connection =_context.CreateConnection())
            {
                var values =await connection.QueryAsync<ResultProductDto>(query);

                return  values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,Address,Type,CoverImage, CategoryName,DealOfTheDay " +
                "from Product inner Join Category on Product.ProductCategory=Category.CategoryID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);

                return values.ToList();
            }
        }
    }
}
