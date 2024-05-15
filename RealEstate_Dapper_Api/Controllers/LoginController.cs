using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(CreateLoginDto request)
        {
            string query = "Select * from AppUser where UserName=@username and Password=@password";

            string query2 = "Select UserId from AppUser where UserName=@username and Password=@password";

            var parameters = new DynamicParameters();

            parameters.Add("@username",request.UserName);

            parameters.Add("@password",request.Password);

            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters);
                var values2=await connection.QueryFirstOrDefaultAsync<GetAppUserIdDto>(query2,parameters);

                if(values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();

                    model.Username= request.UserName;
                    model.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }

                else
                {
                    return Ok("Username or password is wrong");
                }
            }
        }
    }
}
