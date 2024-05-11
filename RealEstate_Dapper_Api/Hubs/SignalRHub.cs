using Microsoft.AspNetCore.SignalR;
using System.Net.Http;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task SendCategoryCount()
        {
            #region Category Count
            var client1 = _httpClientFactory.CreateClient();

            var responseMessage1 = await client1.GetAsync("https://localhost:44322/api/Statistics/CategoryCount");


            var value = await responseMessage1.Content.ReadAsStringAsync();

            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            #endregion
        }
    }
}
