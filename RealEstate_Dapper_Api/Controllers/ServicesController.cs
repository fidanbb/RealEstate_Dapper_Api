using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetServiceList()
        {
            return Ok(await _serviceRepository.GetAllServiceAsync());
        }

        [HttpPost]

        public async Task<IActionResult> CreateService(CreateServiceDto request)
        {
            await _serviceRepository.CreateServiceAsync(request);

            return Ok("Service created successfully...");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteService(int id)
        {
            _serviceRepository.DeleteServiceAsync(id);
            return Ok("Service deleted successfully...");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateService(UpdateServiceDto request)
        {
            _serviceRepository.UpdateServiceAsync(request);

            return Ok("Service updated successfully...");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetService(int id)
        {
            return Ok(await _serviceRepository.GetServiceAsync(id));
        }


    }
}
