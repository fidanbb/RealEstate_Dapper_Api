using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository:IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public Task CreateToDoListAsync(CreateToDoListDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            var query = "Select * from ToDoList";

            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultToDoListDto>(query);

                return values.ToList();
            }
        }

        public Task<GetByIDToDoListDto> GetToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoListAsync(UpdateToDoListDto request)
        {
            throw new NotImplementedException();
        }
    }
}
