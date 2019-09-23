using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeWebApi
{
    public class CustomActionFilter2 : Attribute,IActionFilter
    {
        //public int value { get; set; }
        private EmployeeWebApi.Models.EmployeeModel _employeeModel = new Models.EmployeeModel();
       //public CustomActionFilter2(int val)
       // {
       //     this.value = val;
       // }
        public bool AllowMultiple => true;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            _employeeModel.LogRequest("start-"+actionContext.ActionDescriptor.ActionName, actionContext.ActionDescriptor.ControllerDescriptor.ControllerName, 1);


             var result = continuation();
            result.Wait();

            _employeeModel.LogRequest("end-" + actionContext.ActionDescriptor.ActionName, actionContext.ActionDescriptor.ControllerDescriptor.ControllerName, 1);
            return result;
        }
    }
}