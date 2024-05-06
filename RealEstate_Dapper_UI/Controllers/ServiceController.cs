using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Services/GetServiceList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateService() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateService(CreateServiceDto request)
        {
            if (!ModelState.IsValid) { return View(); }
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/Services/CreateService", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }



        public async Task<IActionResult> DeleteService(int? id)
        {
            if (id is null) return BadRequest();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Services/GetService/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44322/api/Services/DeleteService/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Services/GetService/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateService(UpdateServiceDto request)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44322/api/Services/UpdateService", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
