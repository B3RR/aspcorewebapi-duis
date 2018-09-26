using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using aspcorewebapi_duis.Enums;
using aspcorewebapi_duis.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace aspcorewebapi_duis.Filters
{

    public class DuisAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IHostingEnvironment _env;

        public DuisAuthorizationFilter(IHostingEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env)); ;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context?.HttpContext?.User?.Identity?.IsAuthenticated != true)
            {
                throw new DuisException("You must sing in");
            }
            var claims = context?.HttpContext?.User?.Identities.Where(x => x.AuthenticationType == "DUIS" 
                                                                           && x.Name == _env.ApplicationName.ToLower()).FirstOrDefault()?.Claims;
            if (claims != null && claims.Count() > 0)
            {
                var verb = context.ActionDescriptor.RouteValues.Single(x => x.Key == "action").Value.ToUpper();
                var controller = Helpers.ControllersHelper.RemoveVersionFromControllerName(context.ActionDescriptor.RouteValues.Single(x => x.Key == "controller").Value);
                var claim = claims.Where(x => x.Type == controller).FirstOrDefault();
                if (claim != null)
                {
                    if (Int32.TryParse(claim.Value, out var duisId))
                    {
                        if (!Helpers.EnumsHelper.GetEnumFieldText((DuisEnum)duisId).Contains(verb))
                        {
                            throw new DuisException($"You did't have DUIS permissions for '{controller}' with verb '{verb}', you can only '{((DuisEnum)duisId).ToString()}'");
                        }
                    }
                    else
                    {
                        throw new DuisException($"You did't have DUIS permissions for '{controller}' with value '{claim.Value}'");
                    }
                }
                else
                {
                    throw new DuisException($"You did't have DUIS permissions for '{controller}'");
                }
            }
            else
            {
                throw new DuisException("You did't have DUIS permissions");
            }
        }
    }
}
