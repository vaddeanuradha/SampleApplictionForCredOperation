using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeModel _employee;
        public EmployeeController()
        {
            _employee = new EmployeeModel();
        }
        [HttpGet]
        //[CustomActionFilter(0)]
        //[CustomActionFilter(5)]
        //[CustomActionFilter(1)]
        //[CustomExceptionFilter]
        public HttpResponseMessage GetEmployees()
        {
            var data= _employee.GetEmployees();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                var response= Request.CreateResponse(HttpStatusCode.NotFound, "No data available");
                 return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data available");
                //throw new HttpResponseException(response);

                //throw new ArrayTypeMismatchException(); 
            }


        }
        [HttpGet]
        [Route("api/EmployeeById/{id}")]
        public EmployeeModel GetEmployeeById(int id)
        {
            return _employee.GetEmployeeById(id);
        }

        [HttpPost]
        public HttpResponseMessage CreateEmployee([FromBody] EmployeeModel emp)
        {

            try
            {
                var result = _employee.CreateEmployee(emp);

                if (result)
                {
                    var response= Request.CreateResponse();
                    response.Content = new StringContent("Successfully Added");
                    response.StatusCode = HttpStatusCode.Accepted;
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data");
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee([FromBody] EmployeeModel emp)
        {

           var result= _employee.UpdateEmployee(emp);

            if(result)
            {
                Ok();
            }
            return InternalServerError();

        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
        }

    }
}
