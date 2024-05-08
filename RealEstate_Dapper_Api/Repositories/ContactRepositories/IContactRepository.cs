using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactResultDto>> GetLast4ContactAsync();

        Task CreateContactAsync(CreateContactDto request);

        Task DeleteContactAsync(int id);


        Task<GetByIDContactDto> GetContactAsync(int id);
    }
}
