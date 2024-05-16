
using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AllProductCountAsync()
        {
            string query = $"Select Count(*) from Product";

            using (var connection=_context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);

                return values;
            }
        }

        public async Task<int> ProductCountByEmployeeIdAsync(int id)
        {
            string query = $"Select Count(*) from Product where EmployeeId = @employeeID";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeID",id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query,parameters);

                return values;
            }
        }

        public async Task<int> ProductCountByStatusFalseAsync(int id)
        {
            string query = $"Select Count(*) from Product where EmployeeId = @employeeID and ProductStatus=@status";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeID", id);
            parameters.Add("@status",false);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);

                return values;
            }
        }

        public async Task<int> ProductCountByStatusTrueAsync(int id)
        {
            string query = $"Select Count(*) from Product where EmployeeId = @employeeID and ProductStatus=@status";

            var parameters = new DynamicParameters();

            parameters.Add("@employeeID", id);
            parameters.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);

                return values;
            }
        }
    }
}
