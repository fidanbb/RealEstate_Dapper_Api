using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            #region Active Category Count

            var client1 = _httpClientFactory.CreateClient();

            var responseMessage1 = await client1.GetAsync("https://localhost:44322/api/Statistics/ActiveCategoryCount");


            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();

            ViewBag.activeCategoryCount = jsonData1;

            #endregion

            #region Passive Category Count
            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client2.GetAsync("https://localhost:44322/api/Statistics/PassiveCategoryCount");


            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            ViewBag.passiveCategoryCount = jsonData2;

            #endregion

            #region Active Employee Count
            var client3 = _httpClientFactory.CreateClient();

            var responseMessage3 = await client3.GetAsync("https://localhost:44322/api/Statistics/ActiveEmployeeCount");


            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

            ViewBag.activeEmployeeCount = jsonData3;

            #endregion

            #region Apartment Count
            var client4 = _httpClientFactory.CreateClient();

            var responseMessage4 = await client4.GetAsync("https://localhost:44322/api/Statistics/ApartmentCount");


            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

            ViewBag.apartmentCount = jsonData4;

            #endregion

            #region Average Product Prices By Rent
            var client5 = _httpClientFactory.CreateClient();

            var responseMessage5 = await client5.GetAsync("https://localhost:44322/api/Statistics/AverageProductPriceByRent");


            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();

          

            decimal averageProductPriceByRent = decimal.Parse(jsonData5, CultureInfo.InvariantCulture);
            ViewBag.averageProductPriceByRent = averageProductPriceByRent.ToString("0.00");

            #endregion

            #region Average Product Pricec By Sale
            var client6 = _httpClientFactory.CreateClient();

            var responseMessage6 = await client6.GetAsync("https://localhost:44322/api/Statistics/AverageProductPriceBySale");


            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();


            decimal averageProductPriceBySale = decimal.Parse(jsonData6, CultureInfo.InvariantCulture);
            ViewBag.averageProductPriceBySale = averageProductPriceBySale.ToString("0.00");

            #endregion

            #region Average Room Count
            var client7 = _httpClientFactory.CreateClient();

            var responseMessage7 = await client6.GetAsync("https://localhost:44322/api/Statistics/AverageRoomCount");


            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();

            ViewBag.averageRoomCount = jsonData7;

            #endregion

            #region Category Count
            var client8 = _httpClientFactory.CreateClient();

            var responseMessage8 = await client8.GetAsync("https://localhost:44322/api/Statistics/CategoryCount");


            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();

            ViewBag.categoryCount = jsonData8;

            #endregion

            #region CategoryNameByMaxProductCount
            var client9 = _httpClientFactory.CreateClient();

            var responseMessage9 = await client9.GetAsync("https://localhost:44322/api/Statistics/CategoryNameByMaxProductCount");


            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();

            ViewBag.categoryNameByMaxProductCount = jsonData9;

            #endregion

            #region CityNameByMaxProductCount
            var client10 = _httpClientFactory.CreateClient();

            var responseMessage10 = await client10.GetAsync("https://localhost:44322/api/Statistics/CityNameByMaxProductCount");


            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();

            ViewBag.cityNameByMaxProductCount = jsonData10;

            #endregion

            #region DifferentCityCount
            var client11 = _httpClientFactory.CreateClient();

            var responseMessage11 = await client11.GetAsync("https://localhost:44322/api/Statistics/DifferentCityCount");


            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();

            ViewBag.differentCityCount = jsonData11;

            #endregion

            #region EmployeeNameByMaxProductCount
            var client12 = _httpClientFactory.CreateClient();

            var responseMessage12 = await client12.GetAsync("https://localhost:44322/api/Statistics/EmployeeNameByMaxProductCount");


            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();

            ViewBag.employeeNameByMaxProductCount = jsonData12;

            #endregion

            #region LastProductPrice
            var client13 = _httpClientFactory.CreateClient();

            var responseMessage13 = await client13.GetAsync("https://localhost:44322/api/Statistics/LastProductPrice");


            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();

            ViewBag.lastProductPrice = jsonData13;

            #endregion

            #region NewestBuildingYear
            var client14 = _httpClientFactory.CreateClient();

            var responseMessage14 = await client14.GetAsync("https://localhost:44322/api/Statistics/NewestBuildingYear");


            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();

            ViewBag.newestBuildingYear = jsonData14;

            #endregion

            #region OldestBuildingYear
            var client15 = _httpClientFactory.CreateClient();

            var responseMessage15 = await client15.GetAsync("https://localhost:44322/api/Statistics/OldestBuildingYear");


            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();

            ViewBag.oldestBuildingYear = jsonData15;

            #endregion

            #region ProductCount
            var client16 = _httpClientFactory.CreateClient();

            var responseMessage16 = await client16.GetAsync("https://localhost:44322/api/Statistics/ProductCount");


            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();

            ViewBag.productCount = jsonData16;

            #endregion

            return View();
        }
    }
}
