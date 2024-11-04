using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Interfaces.Auth;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;

namespace Shop.Endpoint.Rest.ActionFilters
{
    public class JWTAuthorize : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            IJwtAuthentication jwtServicd = context.HttpContext.RequestServices.GetRequiredService<IJwtAuthentication>();

            var token = context.HttpContext.Request.Headers["Authorization"];
            if(!string.IsNullOrEmpty(token))
            {
                if(!jwtServicd.TokenIsValid(token))
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseDto
                    {
                        Message = AuthMessageResult.UnAuthorize,
                        StatusCode = 401,
                        Result = null
                    });
                }

            }
            else
            {
                context.Result = new UnauthorizedObjectResult(new ResponseDto
                {
                    Message = AuthMessageResult.UnAuthorize,
                    StatusCode = 401,
                    Result = null
                });
            }
        }
    }
}
