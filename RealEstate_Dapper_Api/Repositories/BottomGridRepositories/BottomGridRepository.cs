
using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGridAsync(CreateBottomGridDto request)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) " +
       "values (@icon,@title,@description)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@icon", request.Icon);
            parametrs.Add("@title", request.Title);
            parametrs.Add("@description", request.Description);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            string query = "Delete from BottomGrid where  BottomGridID =@bottomGridID";

            var parametrs = new DynamicParameters();
            parametrs.Add("@bottomGridID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetBottomGridAsync(int id)
        {
            string query = "Select * from BottomGrid Where BottomGridID = @bottomGridID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@bottomGridID", id);

            using (var connection = _context.CreateConnection())
            {

                var value = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parametrs);

                return value;
            }
        }

        public async Task UpdateBottomGridAsync(UpdateBottomGridDto request)
        {
            string query = "Update BottomGrid Set Icon=@icon,Title=@title,Description=@description where bottomGridID=@bottomGridID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@icon", request.Icon);
            parametrs.Add("@title", request.Title);
            parametrs.Add("@description", request.Description);
         
            parametrs.Add("@bottomGridID", request.BottomGridID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
