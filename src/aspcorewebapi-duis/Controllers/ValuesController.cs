using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspcorewebapi_duis.Filters;
using aspcorewebapi_duis.Enums;
using aspcorewebapi_duis.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;

namespace aspcorewebapi_duis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(DuisAuthorizationFilter))]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userInfo = new
            {
                ID = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value,
                Login = User.Identity.Name,
                FIO = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault()?.Value,
                EMail = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value
            };
            return Json(userInfo);
        }

    }
}
