using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]

        public async Task<IActionResult> ProductList()
        {
            return Ok(await _productRepository.GetAllProductAsync());
        }

        [HttpGet]

        public async Task<IActionResult> ProductListWithCategory()
        {
            return Ok(await _productRepository.GetAllProductWithCategoryAsync());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> ActivateDealOfTheDay(int id)
        {
            await _productRepository.ActivateDealOfTheDayAsync(id);
            return Ok("Deal Of The Day Activated");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> DeactivateDealOfTheDay(int id)
        {
            await _productRepository.DeactivateDealOfTheDayAsync(id);
            return Ok("Deal Of The Day deactivated");
        }

        [HttpGet]

        public async Task<IActionResult> LastFiveProductList()
        {

            return Ok(await _productRepository.GetLastFiveProductsAsync());
        }

        [HttpGet]

        public async Task<IActionResult> ProductActiveAdvertListByEmployeeId(int id)
        {
            return Ok(await _productRepository.GetActiveProductAdvertListByEmployeeAsync(id));
        }
        [HttpGet]

        public async Task<IActionResult> ProducPassiveAdvertListByEmployeeId(int id)
        {
            return Ok(await _productRepository.GetPassiveProductAdvertListByEmployeeAsync(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto request)
        {
            await _productRepository.CreateProductAsync(request);

            return Ok("Product succesfully create");
        }

        [HttpGet]

        public async Task<IActionResult> GetProductByProductId(int id)
        {

            return Ok(await _productRepository.GetProductByProductIdDtoAsync(id));
        }

        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            return Ok(await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city));
        }

        [HttpGet("GetProductsByDealOfDayTrueWithCategory")]

        public async Task<IActionResult> GetProductsByDealOfDayTrueWithCategory()
        {
            return Ok(await _productRepository.GetProductsByDealOfDayTrueWithCategoryAsync());
        }


    }
}
