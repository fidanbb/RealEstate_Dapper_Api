using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]

        public async Task<IActionResult> BottomGridList()
        {
            return Ok(await _bottomGridRepository.GetAllBottomGridAsync());
        }

        [HttpPost]

        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto request)
        {
            await _bottomGridRepository.CreateBottomGridAsync(request);

            return Ok("BottomGrid created successfully...");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            _bottomGridRepository.DeleteBottomGridAsync(id);
            return Ok("BottomGrid deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto request)
        {
            _bottomGridRepository.UpdateBottomGridAsync(request);

            return Ok("BottomGrid updated successfully...");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBottomGrid(int id)
        {
            return Ok(await _bottomGridRepository.GetBottomGridAsync(id));
        }
    }
}
