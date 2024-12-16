using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shop.Application.Mapper;
using Shop.Domain.Dtos;

namespace Shop.Endpoint.Rest.ActionFilters
{
    public class ParamValidatorAttribute :Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string actionName = context.RouteData.Values["action"].ToString();
            string controllerName = context.RouteData.Values["controller"].ToString();
            string ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (!context.ModelState.IsValid)
            {

                context.HttpContext.Response.StatusCode = 400;
                context.Result = new BadRequestObjectResult(new OperationResult(false, JsonConvert.SerializeObject(context.ModelState.Values.SelectMany(x => x.Errors))).BadRequest());

            }
            await next();
        }
    }
}
