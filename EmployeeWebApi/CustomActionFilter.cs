using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EmployeeWebApi
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public int id { get; set; }
        public CustomActionFilter(int id)
        {
            this.id = id;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;

            if (response.Content.ReadAsAsync<List<EmployeeModel>>().Result.Count > id)
            {
                Console.WriteLine("success");
                Trace.WriteLine("Completed");

            }
            else
            {
                var failedResponse = actionExecutedContext.Request.CreateResponse();
                failedResponse.Content = new StringContent("no data founds");

                actionExecutedContext.Response = failedResponse;
            }

            throw new Exception();
        }
    }
}