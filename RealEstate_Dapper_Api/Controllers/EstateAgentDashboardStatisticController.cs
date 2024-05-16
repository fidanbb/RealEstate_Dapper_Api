using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticsRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("AllProductCount")]
        public async Task<IActionResult> AllProductCount()
        {
            return Ok(await _statisticsRepository.AllProductCountAsync());
        }
        [HttpGet("ProductCountByEmployeeId")]
        public async Task<IActionResult> ProductCountByEmployeeId(int id)
        {
            return Ok(await _statisticsRepository.ProductCountByEmployeeIdAsync(id));
        }
        [HttpGet("ProductCountByStatusFalse")]
        public async Task<IActionResult> ProductCountByStatusFalse(int id)
        {
            return Ok(await _statisticsRepository.ProductCountByStatusFalseAsync(id));
        }
        [HttpGet("ProductCountByStatusTrue")]
        public async Task<IActionResult> AlProductCountByStatusTruelProductCount(int id)
        {
            return Ok(await _statisticsRepository.ProductCountByStatusTrueAsync(id));
        }

    }
}
