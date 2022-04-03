using System.Net;
using Library.Infraestructure.ObjectResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Infraestructure.Exceptions;

namespace Library.Infraestructure.Filters
{
	public class HttpGlobalExceptionFilter: IExceptionFilter
	{
		public HttpGlobalExceptionFilter()
		{
		}

		public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(UnauthorizedException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception.GetType() == typeof(NotFoundException))
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception.GetType() == typeof(ForbiddenException))
            {
                context.Result = new JsonResult(context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An error ocurred." },
                };
                json.DeveloperMeesage = context.Exception;

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }
		private class JsonErrorResponse
		{
			public string[] Messages { get; set; }
			public object DeveloperMeesage { get; set; }
			public object InnerException { get; set; }
		}
	}
}

