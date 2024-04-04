using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
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

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto request)
        {
            await _catogoryRepository.CreateCategoryAsync(request);

            return Ok("Category created successfully...");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            _catogoryRepository.DeleteCategoryAsync(id);
            return Ok("Category deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto request)
        {
            _catogoryRepository.UpdateCategoryAsync(request);

            return Ok("Category updated successfully...");
        }
    }
}
