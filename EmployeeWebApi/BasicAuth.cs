using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeWebApi
{
    public class BasicAuth:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "User is not logged in");
            }
            else
            {

                // username:password
                var data = actionContext.Request.Headers.Authorization.Parameter;
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(data));
                var stringArray = credentials.Split(':');
                string userName = stringArray[0];
                string password = stringArray[1];

                if(userName=="testuser" && password=="test123")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Login Failed");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}