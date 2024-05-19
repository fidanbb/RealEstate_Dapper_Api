using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultReceivedMessageDto>> GetLast3ReceivedMessagesByUserAsync(int id);
    }
}
