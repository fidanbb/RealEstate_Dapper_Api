using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class BottomGridController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BottomGridController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/BottomGrids/BottomGridList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBottomGrid() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto request)
        {
            if (!ModelState.IsValid) { return View(); }
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/BottomGrids/CreateBottomGrid", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }



        public async Task<IActionResult> DeleteBottomGrid(int? id)
        {
            if (id is null) return BadRequest();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/BottomGrids/GetBottomGrid/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44322/api/BottomGrids/DeleteBottomGrid/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> UpdateBottomGrid(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/BottomGrids/GetBottomGrid/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateBottomGridDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto request)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44322/api/BottomGrids/UpdateBottomGrid", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
