using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PopularLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PopularLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/PopularLocations/PopularLocationList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatePopularLocation() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto request)
        {
            if (!ModelState.IsValid) { return View(); }
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/PopularLocations/CreatePopularLocation", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }



        public async Task<IActionResult> DeletePopularLocation(int? id)
        {
            if (id is null) return BadRequest();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/PopularLocations/GetPopularLocation/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44322/api/PopularLocations/DeletePopularLocation/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> UpdatePopularLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/PopularLocations/GetPopularLocation/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto request)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44322/api/PopularLocations/UpdatePopularLocation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
