using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstatetAgentDashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _EstatetAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory,
                                                                ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _loginService.GetUserId;

            var client=_httpClientFactory.CreateClient();
            #region All Products
            var responseMessage1 =await client.GetAsync("https://localhost:44322/api/EstateAgentDashboardStatistic/AllProductCount");

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1=await responseMessage1.Content.ReadAsStringAsync();

                ViewBag.allProductsCount = jsonData1;
            }
            #endregion

            #region Product Count ByEmployee
            var responseMessage2 = await client.GetAsync($"https://localhost:44322/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+userId);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                ViewBag.productCountByEmployee = jsonData2;
            }
            #endregion

            #region Product Count By Status False
            var responseMessage3 = await client.GetAsync("https://localhost:44322/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + userId);

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();

                ViewBag.productCountByStatusFalse = jsonData3;
            }
            #endregion


            #region Product Count By Status True
            var responseMessage4 = await client.GetAsync("https://localhost:44322/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + userId);

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

                ViewBag.productCountByStatusTrue = jsonData4;
            }
            #endregion

            return View();
        }
    }
}
