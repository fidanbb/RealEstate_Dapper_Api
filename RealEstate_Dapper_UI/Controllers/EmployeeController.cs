using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Services;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public EmployeeController(IHttpClientFactory httpClientFactory,ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var user = User.Claims;

            var userId = _loginService.GetUserId;
            var token=User.Claims.FirstOrDefault(x=>x.Type=="realestatetoken")?.Value;

           

            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();

                var responseMessage = await client.GetAsync("https://localhost:44322/api/Employees/EmployeeList");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);

                    return View(values);
                }
            }
           
            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee() { return View(); }

        [HttpPost]

        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto request)
        {
            if(!ModelState.IsValid) { return View(); }
            var client=_httpClientFactory.CreateClient();

            var jsonData=JsonConvert.SerializeObject(request);

            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:44322/api/Employees/CreateEmployee",content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }



        public async Task<IActionResult>DeleteEmployee(int? id)
        {
            if (id is null) return BadRequest();

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Employees/GetEmployee/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return NotFound();  
            }

            var client2 = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44322/api/Employees/DeleteEmployee/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Employees/GetEmployee/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto request)
        {
            if (!ModelState.IsValid) return View();

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(request);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44322/api/Employees/UpdateEmployee", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
