using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateWoWeAreDetailAsync(CreateWhoWeAreDetailDto request)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) " +
                "values (@title,@subTitle,@description1,@description2)";

            var parametrs = new DynamicParameters();

            parametrs.Add("@title", request.Title);
            parametrs.Add("@subTitle", request.Subtitle);
            parametrs.Add("@description1", request.Description1);
            parametrs.Add("@description2", request.Description2);



            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "Delete from WhoWeAreDetail where  WhoWeAreDetailID =@whoWeAreDetailID";

            var parametrs = new DynamicParameters();
            parametrs.Add("@whoWeAreDetailID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailAsync(int id)
        {
            string query = "Select * from WhoWeAreDetail Where WhoWeAreDetailID = @whoWeAreDetailID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@whoWeAreDetailID", id);

            using (var connection = _context.CreateConnection())
            {

                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parametrs);

                return value;
            }
        }

        public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto request)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subtitle," +
                " Description1=@description1, Description2=@description2 " +
               "where WhoWeAreDetailID=@whoWeAreDetailID";

            var parametrs = new DynamicParameters();

            parametrs.Add("@title", request.Title);
            parametrs.Add("@subtitle", request.Subtitle);
            parametrs.Add("@description1", request.Description1);
            parametrs.Add("@description2", request.Description2);
            parametrs.Add("@whoWeAreDetailID", request.WhoWeAreDetailID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametrs);
            }
        }
    }
}
