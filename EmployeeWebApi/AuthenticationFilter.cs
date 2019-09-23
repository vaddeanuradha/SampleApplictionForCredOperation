using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Security.Principal;

namespace EmployeeWebApi
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.ActionContext.Request.Headers.Authorization == null)
            {

                context.ActionContext.Response =context.Request.CreateResponse(HttpStatusCode.BadRequest, "User is not logged in");
            }
            else
            {

                // username:password
                var data = context.Request.Headers.Authorization.Parameter;
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(data));
                var stringArray = credentials.Split(':');
                string userName = stringArray[0];
                string password = stringArray[1];

                if (userName == "testuser" && password == "test123")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                }
                else
                {
                    context.ActionContext.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, "User is failed logged in");
                }

            }
            return Task.Run(()=>0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() => 0);
        }
    }
}