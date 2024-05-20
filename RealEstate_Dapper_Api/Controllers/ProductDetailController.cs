using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("GetProductDetailByProductId")]

        public async Task<IActionResult> GetProductDetailByProductId(int id)
        {

            return Ok(await _productRepository.GetProductDetailByProductIdDtoAsync(id));
        }
    }
}
