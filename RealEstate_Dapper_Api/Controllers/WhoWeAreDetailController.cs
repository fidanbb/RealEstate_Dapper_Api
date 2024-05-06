using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]

        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();

            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto request)
        {
            await _whoWeAreDetailRepository.CreateWoWeAreDetailAsync(request);

            return Ok("WhoWeAreDetail created successfully...");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreDetailRepository.DeleteWhoWeAreDetailAsync(id);
            return Ok("WhoWeAreDetail deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto request)
        {
            _whoWeAreDetailRepository.UpdateWhoWeAreDetailAsync(request);

            return Ok("WhoWeAreDetail updated successfully...");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            return Ok(await _whoWeAreDetailRepository.GetWhoWeAreDetailAsync(id));
        }
    }
}
