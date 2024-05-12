﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCreateController : ControllerBase
    {
        [HttpPost]

        public IActionResult CreateToken(GetCheckAppUserViewModel request)
        {
            var values = JwtTokenGenerator.GenerateToken(request);

            return Ok(values);
        }
    }
}
