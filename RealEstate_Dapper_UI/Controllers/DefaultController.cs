using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Categories/CategoryList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialSearch()
        {
            return  PartialView();
        }

        [HttpPost]

        [HttpGet]
        public IActionResult PartialSearch(string searchKeyValue,string city,int category)
        {
            TempData["seachText"] = searchKeyValue;
            TempData["city"] = city;
            TempData["category"] = category;
            return RedirectToAction("PropertyListWithSearch","Property");
        }
    }
}
