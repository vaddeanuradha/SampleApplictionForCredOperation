using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var response = Client.http.GetAsync("Employee").Result;
            var employeeList = response.Content.ReadAsAsync<List<Employee>>().Result;
            return View(employeeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            var response = Client.http.PostAsJsonAsync<Employee>("Employee", emp).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {


            var response = Client.http.GetAsync("EmployeeById/" + id).Result;
            var employee = response.Content.ReadAsAsync<Employee>().Result;
            return View(employee);

        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var response = Client.http.PutAsJsonAsync<Employee>("Employee", emp).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var response = Client.http.DeleteAsync("Employee/" + id).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var response = Client.http.GetAsync("EmployeeById/" + id).Result;
            var employee = response.Content.ReadAsAsync<Employee>().Result;
            return View(employee);
        }
    }
}