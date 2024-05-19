using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("GetLast3ReceivedMessagesByUser")]
        public async Task<IActionResult> GetLast3ReceivedMessagesByUser(int id)
        {
            return Ok(await _messageRepository.GetLast3ReceivedMessagesByUserAsync(id));
        }
    }
}
