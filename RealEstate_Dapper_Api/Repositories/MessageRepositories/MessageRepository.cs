using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context    = context;
        }
        public async Task<List<ResultReceivedMessageDto>> GetLast3ReceivedMessagesByUserAsync(int id)
        {
            string query = "Select top(3) MessageId,Name,Subject,Detail,SendDate,IsRead,UserImageUrl from Message inner join AppUser on Message.Sender=AppUser.UserId where Receiver = @receiverId order by SendDate desc";

            var parameters = new DynamicParameters();

            parameters.Add("@receiverId", id);

            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultReceivedMessageDto>(query,parameters);

                return values.ToList();
            }
        }
    }
}
