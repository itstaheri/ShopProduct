using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Interfaces.Auth;
using Shop.Domain.Enums;
using System;
using System.Linq;

namespace Shop.Endpoint.Rest.ActionFilters
{
    public class CheckPermision : Attribute, IActionFilter
    {
        private Permission Permission;
        public CheckPermision(Permission permission)
        {
            Permission = permission;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var jwtService = context.HttpContext.RequestServices.GetRequiredService<IJwtAuthentication>();
            var permissions = jwtService.ReadTokenClaims().Permissions;
            if (!permissions.Contains(Permission))
            {
                context.Result = new ObjectResult("forbidden");
            }

        }
    }
}
