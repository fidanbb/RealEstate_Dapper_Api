using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ActiveCategoryCount")]

        public async Task<IActionResult> ActiveCategoryCount()
        {
            return Ok(await _statisticsRepository.ActiveCategoryCountAsync());
        }

        [HttpGet("ActiveEmployeeCount")]

        public async Task<IActionResult> ActiveEmployeeCount()
        {
            return Ok(await _statisticsRepository.ActiveEmployeeCountAsync());
        }
        [HttpGet("ApartmentCount")]

        public async Task<IActionResult> ApartmentCount()
        {
            return Ok(await _statisticsRepository.ApartmentCountAsync());
        }

        [HttpGet("AverageProductPriceByRent")]

        public async Task<IActionResult> AverageProductPriceByRent()
        {
            return Ok(await _statisticsRepository.AverageProductPriceByRentAsync());
        }

        [HttpGet("AverageProductPriceBySale")]

        public async Task<IActionResult> AverageProductPriceBySale()
        {
            return Ok(await _statisticsRepository.AverageProductPriceBySaleAsync());
        }
        [HttpGet("AverageRoomCount")]

        public async Task<IActionResult> AverageRoomCount()
        {
            return Ok(await _statisticsRepository.AverageRoomCountAsync());
        }

        [HttpGet("CategoryCount")]

        public async Task<IActionResult> CategoryCount()
        {
            return Ok(await _statisticsRepository.CategoryCountAsync());
        }

        [HttpGet("CategoryNameByMaxProductCount")]

        public async Task<IActionResult> CategoryNameByMaxProductCount()
        {
            return Ok(await _statisticsRepository.CategoryNameByMaxProductCountAsync());
        }

        [HttpGet("CityNameByMaxProductCount")]

        public async Task<IActionResult> CityNameByMaxProductCountAsync()
        {
            return Ok(await _statisticsRepository.CityNameByMaxProductCountAsync());
        }

        [HttpGet("DifferentCityCount")]

        public async Task<IActionResult> DifferentCityCountAsync()
        {
            return Ok(await _statisticsRepository.DifferentCityCountAsync());
        }

        [HttpGet("EmployeeNameByMaxProductCount")]

        public async Task<IActionResult> EmployeeNameByMaxProductCountAsync()
        {
            return Ok(await _statisticsRepository.EmployeeNameByMaxProductCountAsync());
        }

        [HttpGet("LastProductPrice")]

        public async Task<IActionResult> LastProductPrice()
        {
            return Ok(await _statisticsRepository.LastProductPriceAsync());
        }

        [HttpGet("NewestBuildingYear")]

        public async Task<IActionResult> NewestBuildingYear()
        {
            return Ok(await _statisticsRepository.NewestBuildingYearAsync());
        }
        [HttpGet("OldestBuildingYear")]

        public async Task<IActionResult> OldestBuildingYear()
        {
            return Ok(await _statisticsRepository.OldestBuildingYearAsync());
        }

        [HttpGet("PassiveCategoryCount")]

        public async Task<IActionResult> PassiveCategoryCountAsync()
        {
            return Ok(await _statisticsRepository.PassiveCategoryCountAsync());
        }
        [HttpGet("ProductCount")]

        public async Task<IActionResult> ProductCountAsync()
        {
            return Ok(await _statisticsRepository.ProductCountAsync());
        }
    }
}
