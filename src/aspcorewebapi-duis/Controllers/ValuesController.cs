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

namespace aspcorewebapi_duis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(DuisAuthorizationFilter))]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var list=new List<string>();
            list.Add($"ID: {User.Claims.Where(x=>x.Type==ClaimTypes.NameIdentifier).FirstOrDefault()?.Value}");
            list.Add($"Login: {User.Identity.Name}");
            list.Add($"FIO: {User.Claims.Where(x=>x.Type==ClaimTypes.Surname).FirstOrDefault()?.Value}");
            list.Add($"Email: {User.Claims.Where(x=>x.Type==ClaimTypes.Email).FirstOrDefault()?.Value}");
            return list;
        }

        
    }
}
