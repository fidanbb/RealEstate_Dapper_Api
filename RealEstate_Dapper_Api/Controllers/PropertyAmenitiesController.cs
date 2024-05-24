using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AmenityRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;
        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id)
        {
            return Ok(await _propertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id));
        }
    }
}
