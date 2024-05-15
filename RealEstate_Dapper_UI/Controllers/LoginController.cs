using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using RealEstate_Dapper_UI.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate_Dapper_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> Index(CreateLoginDto request)
        {

            var client=_httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(request),Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/Login", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();

                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions
                {
                    PropertyNamingPolicy =JsonNamingPolicy.CamelCase
                });

                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler handler=new JwtSecurityTokenHandler();

                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims=token.Claims.ToList();

                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("realestatetoken", tokenModel.Token));

                        var claimsIdentity=new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true

                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal
                            (claimsIdentity),authProps);

                        return RedirectToAction("Index","Employee");
                    }
                }
            }
            return View();
        }
    }
}
