using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatogoryRepository _catogoryRepository;

        public CategoriesController(ICatogoryRepository catogoryRepository)
        {
            _catogoryRepository = catogoryRepository;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values=await _catogoryRepository.GetAllCategoryAsync();

            return Ok(values);
        }
    }
}
