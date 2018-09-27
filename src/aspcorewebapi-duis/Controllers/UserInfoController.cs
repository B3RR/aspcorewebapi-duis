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
    public class UserInfoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userInfo = new
            {
                ID = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                Login = User.Identity.Name,
                FIO = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                EMail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                Rules = new Dictionary<string, Dictionary<string, string>>()
            };
            foreach (var identity in User.Identities.Where(x => x.AuthenticationType != "Default"))
            {
                userInfo.Rules.Add(identity.AuthenticationType, new Dictionary<string, string>());
                userInfo.Rules[identity.AuthenticationType] = identity.Claims
                        .Where(x=>x.ValueType==ClaimValueTypes.Integer32)
                        .ToDictionary(k => k.Type, v => ((DuisEnum)Convert.ToInt32(v.Value)).ToString());
            }
            return Json(userInfo);
        }

    }
}
