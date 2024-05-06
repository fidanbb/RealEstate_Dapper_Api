using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }
        public async Task CreatePopularLocationAsync(CreatePopularLocationDto request)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) " +
              "values (@cityName,@imageUrl)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@cityName", request.CityName);
            parametrs.Add("@imageUrl", request.ImageUrl);
      
    

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "Delete from PopularLocation where  LocationID =@locationID";

            var parametrs = new DynamicParameters();
            parametrs.Add("@locationID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * from PopularLocation";

            using (var connection=_context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);

                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocationAsync(int id)
        {
            string query = "Select * from PopularLocation Where LocationID = @locationID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@locationID", id);

            using (var connection = _context.CreateConnection())
            {

                var value = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parametrs);

                return value;
            }
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto request)
        {
            string query = "Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl where LocationID=@locationID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@cityName", request.CityName);
            parametrs.Add("@imageUrl", request.ImageUrl);
            parametrs.Add("@locationID", request.LocationID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
