using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using aspcorewebapi_duis.Core;
using aspcorewebapi_duis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.Threading.Tasks;
using aspcorewebapi_duis.Filters;
using aspcorewebapi_duis.Exceptions;

namespace aspcorewebapi_duis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SQLContext _context;
        public AuthenticationController(SQLContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == username);
            if (user != null)
            {
                await SetCookieIdentityAsync(user);
                return Ok($"200 {user.Login} - success");
            }
            else
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return StatusCode(401, $"401 {username} - fail");
            }
        }

        private async Task SetCookieIdentityAsync(User user)
        {
            if (user != null)
            {
                var rolesIds = _context.RoleUsers.Where(x => x.UserId == user.ID).AsNoTracking().Select(x => x.RoleId).Distinct();
                var rules = _context.Rules.Where(x => rolesIds.Contains(x.RoleId)).AsNoTracking();
                var claimsIdentities = new List<ClaimsIdentity>();
                var claims = new List<Claim>()
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                            new Claim(ClaimsIdentity.DefaultRoleClaimType, "Default"),
                            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString(), ClaimValueTypes.Integer32),
                            new Claim(ClaimTypes.Surname, user.FIO),
                            new Claim(ClaimTypes.Email, user.Email)
                        };

                claimsIdentities.Add(new ClaimsIdentity(claims, "Default", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType));
                foreach (var appName in rules.Select(x => x.ApplicationName).Distinct())
                {
                    claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, appName) };
                    foreach (var rule in rules.Where(x => x.ApplicationName == appName && x.DuisId > 0))
                    {
                        claims.Add(new Claim(rule.Controller, ((int)rule.DuisEnum).ToString(),ClaimValueTypes.Integer32));
                    }
                    if (claims.Count > 1)
                    {
                        claimsIdentities.Add(new ClaimsIdentity(claims, "DUIS", ClaimsIdentity.DefaultNameClaimType, "none"));
                    }
                }
                var cp = new ClaimsPrincipal();
                cp.AddIdentities(claimsIdentities);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);
            }

        }
    }
}
