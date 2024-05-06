using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhoWeAreController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/WhoWeAreDetail/WhoWeAreDetailList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);

                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateWhoWeAreDetail() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto request)
        {
            if (!ModelState.IsValid) { return View(); }
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/WhoWeAreDetail/CreateWhoWeAreDetail", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }

        public async Task<IActionResult> DeleteWhoWeAreDetail(int? id)
        {
            if (id is null) return BadRequest();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/WhoWeAreDetail/GetWhoWeAreDetail/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44322/api/WhoWeAreDetail/DeleteWhoWeAreDetail/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> UpdateWhoWeAreDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/WhoWeAreDetail/GetWhoWeAreDetail/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateWhoWeAreDetailDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto request)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44322/api/WhoWeAreDetail/UpdateWhoWeAreDetail", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
