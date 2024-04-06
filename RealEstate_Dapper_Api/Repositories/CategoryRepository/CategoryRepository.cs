using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICatogoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto request)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@categoryName",request.CategoryName);
            parametrs.Add("@categoryStatus",true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete from Category where  CategoryID =@categoryID";

            var parametrs = new DynamicParameters();  
            parametrs.Add("@categoryID",id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";

            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * from Category Where CategoryId = @categoryID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@categoryID",id);

            using (var connection=_context.CreateConnection())
            {
                
                var value=await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parametrs);

                return value;
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto request)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus " +
                "where categoryID=@categoryID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@categoryName",request.CategoryName);
            parametrs.Add("@categoryStatus",request.CategoryStatus);
            parametrs.Add("@categoryID", request.CategoryID);

            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parametrs);
            }
        }
    }
}
