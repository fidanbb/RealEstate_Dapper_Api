using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public EstateAgentLastProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]

        public async Task<IActionResult>GetLast5ProductsByEmployee(int id)
        {
            return Ok(await _productRepository.GetLastFiveProductsByEmployeeAsync(id));
        }
    }
}
