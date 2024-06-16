using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Models;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
		public DefaultController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
		{
			_httpClientFactory = httpClientFactory;
			_apiSettings = apiSettings.Value;
		}
		public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_apiSettings.BaseUrl);
			var responseMessage = await client.GetAsync("Categories/CategoryList");

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
