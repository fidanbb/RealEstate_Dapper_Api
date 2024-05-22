
using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;


        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public async Task<int> ActiveCategoryCountAsync()
        {
            string query = "Select Count(*) from Category where CategoryStatus=1";
            using (var connection=_context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<int> ActiveEmployeeCountAsync()
        {
            string query = "Select Count(*) from Employee where Status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public  async Task<int> ApartmentCountAsync()
        {
            string query = "Select Count(*) from Product where Title like '%Apartment%'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<decimal> AverageProductPriceByRentAsync()
        {
            string query = "Select Avg(Price) from Product where Type = 'Rent'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);

                return values;
            }
        }

        public async Task<decimal> AverageProductPriceBySaleAsync()
        {
            string query = "Select Avg(Price) from Product where Type = 'Buy'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);

                return values;
            }
        }

        public async Task<int> AverageRoomCountAsync()
        {
            string query = "Select Avg(RoomCount) from ProductDetails ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<int> CategoryCountAsync()
        {
            string query = "Select Count(*) from Category ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<string> CategoryNameByMaxProductCountAsync()
        {
            string query = $"Select top(1) CategoryName,Count(*) from Product " +
                $"Inner Join Category on Product.ProductCategory=Category.CategoryID " +
                $"Group By CategoryName Order By Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);

                return values;
            }
        }

        public async Task<string> CityNameByMaxProductCountAsync()
        {
            string query = $"Select top(1) City,Count(*) from Product " +
               $"Group By City Order By Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);

                return values;
            }
        }

        public async Task<int> DifferentCityCountAsync()
        {
            string query = $"Select Count(Distinct(City)) from Product ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<string> EmployeeNameByMaxProductCountAsync()
        {
            string query = $"Select Name,Count(*) from Product " +
                $"inner join Employee on Product.EmployeeID=Employee.EmployeeID " +
                $"group by Name order by Count(*) Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);

                return values;
            }
        }

        public async Task<decimal> LastProductPriceAsync()
        {
            string query = $"Select top(1) Price from Product order by ProductID desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);

                return values;
            }
        }

        public async Task<string> NewestBuildingYearAsync()
        {
            string query = $"Select top(1) BuildYear from ProductDetails order by BuildYear desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);

                return values;
            }
        }

        public async Task<int> PassiveCategoryCountAsync()
        {
            string query = $"Select Count(*) from Category where CategoryStatus=0 ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<string> OldestBuildingYearAsync()
        {
            string query = $"Select top(1) BuildYear from ProductDetails order by BuildYear asc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);

                return values;
            }
        }

        public async Task<int> ProductCountAsync()
        {
            string query = $"Select Count(*) from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }
    }
}
