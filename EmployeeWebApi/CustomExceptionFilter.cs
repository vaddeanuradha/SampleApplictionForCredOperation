using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EmployeeWebApi
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
           
               actionExecutedContext.Response= actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Exception occured"+actionExecutedContext.Exception.Message);

            throw new Exception();
        }
    }
}