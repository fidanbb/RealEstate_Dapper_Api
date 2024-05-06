using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;
        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }


        [HttpGet]

        public async Task<IActionResult> PopularLocationList()
        {
            return Ok(await _popularLocationRepository.GetAllPopularLocationAsync());
        }

        [HttpPost]

        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto request)
        {
            await _popularLocationRepository.CreatePopularLocationAsync(request);

            return Ok("PopularLocation created successfully...");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _popularLocationRepository.DeletePopularLocationAsync(id);
            return Ok("PopularLocation deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto request)
        {
            _popularLocationRepository.UpdatePopularLocationAsync(request);

            return Ok("PopularLocation updated successfully...");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPopularLocation(int id)
        {
            return Ok(await _popularLocationRepository.GetPopularLocationAsync(id));
        }
    }
}
