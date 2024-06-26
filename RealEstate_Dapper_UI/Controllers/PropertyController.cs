﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Products/ProductListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue,int propertyCategoryId,string city)
        {
           
            searchKeyValue = TempData["seachText"].ToString();

            propertyCategoryId = int.Parse(TempData["category"].ToString());

            city = TempData["city"].ToString();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Products/ResultProductWithSearchList/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]

        public async Task<IActionResult> PropertySingle(string slug,int id)
        {
            ViewBag.i = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44322/api/Products/GetProductByProductId?id="+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetProductByProductIdDto>(jsonData);


            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44322/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

            ViewBag.productId = values.ProductID;
            ViewBag.productTitle = values.Title;
            ViewBag.price = values.Price;
            ViewBag.city = values.City;
            ViewBag.district = values.District;
            ViewBag.address = values.Address;
            ViewBag.type = values.Type;
            ViewBag.description = values.Description;
            ViewBag.availableDate = values.AdvertismentDate;

            ViewBag.slugUrl= values.SlugUrl;
            ViewBag.bathCount = values2.BathCount;
            ViewBag.date =((DateTime.Now - values.AdvertismentDate).Days)/30;

            ViewBag.bedRoomCount = values2.BedRoomCount;
            ViewBag.size = values2.ProductSize;
            ViewBag.roomCount = values2.RoomCount;
            ViewBag.garageCount = values2.GarageSize;
            ViewBag.buildYear = values2.BuildYear;
            ViewBag.location=values2.Location;
            ViewBag.videoUrl =values2.VideoUrl;
            string slugFromTitle = CreateSlug(values.Title);
            ViewBag.slugUrl = slugFromTitle;
            return View();
        }

        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant(); // convert to lower case
            title = title.Replace(" ", "-"); // change spaces to dashes
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", ""); // Remove invalid characters
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim(); // Reduce multiple spaces to single space and remove margins
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); // Replace spaces with dashes
            return title;
        }
    }
}
