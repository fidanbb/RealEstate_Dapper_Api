using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client =_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Products/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> CreateProduct()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44322/api/Categories/CategoryList");

           
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

           var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);


            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.v = categoryValues;
            return View();
        }

        //[HttpGet("ActivateDealOfTheDay")]

        public async Task<IActionResult> ActivateDealOfTheDay(int id)
        {
            var client =_httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Products/ActivateDealOfTheDay/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }

        public async Task<IActionResult> DeactivateDealOfTheDay(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Products/DeactivateDealOfTheDay/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
