using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task CreateToDoListAsync(CreateToDoListDto request);

        Task DeleteToDoListAsync(int id);

        Task UpdateToDoListAsync(UpdateToDoListDto request);

        Task<GetByIDToDoListDto> GetToDoListAsync(int id);
    }
}
