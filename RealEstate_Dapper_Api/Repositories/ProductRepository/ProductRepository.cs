﻿using Azure.Core;
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

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLastFiveProductsAsync()
        {
            string query = $"Select top(5) ProductID,Title,Price,City,District,ProductCategory, " +
                $"CategoryName,AdvertismentDate " +
                $"from Product inner join Category on Product.ProductCategory = Category.CategoryID " +
                $"where Type='For Rent' order by ProductID Desc";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);

                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLastFiveProductsByEmployeeAsync(int id)
        {
            string query = $"Select top(5) ProductID,Title,Price,City,District,ProductCategory, " +
               $"CategoryName,AdvertismentDate " +
               $"from Product inner join Category on Product.ProductCategory = Category.CategoryID " +
               $"where EmployeeId=@employeeId order by ProductID Desc";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeId",id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,parameters);

                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetActiveProductAdvertListByEmployeeAsync(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,Address,Type,CoverImage, CategoryName,DealOfTheDay " +
      "from Product inner Join Category on Product.ProductCategory=Category.CategoryID where EmployeeId=@employeeID and ProductStatus = 1";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeID",id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);

                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetPassiveProductAdvertListByEmployeeAsync(int id)
        {
            string query = "Select ProductID,Title,Price,City,District,Address,Type,CoverImage, CategoryName,DealOfTheDay " +
       "from Product inner Join Category on Product.ProductCategory=Category.CategoryID where EmployeeId=@employeeID and ProductStatus = 0";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeID", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);

                return values.ToList();
            }
        }
    }
}
