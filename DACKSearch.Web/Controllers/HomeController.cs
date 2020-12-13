using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DACKSearch.Web.Models;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DACKSearch.Web.Controllers
{
    public class HomeController : Controller
    { 
        public async Task<IActionResult> Index(IFormCollection form)
        {
            if (form.Count > 0)
            {
                string apiUrl = "http://localhost:1154/";

                IEnumerable<EmployeeSearch> employees = new List<EmployeeSearch>();
                
                using (var client = new HttpClient())
                {
                    string employeeText = null;
                    string departmentText = null;
                    string subdepartmentText = null;
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    switch (form["SearchFilter"])
                    {
                        case "EmployeeText":
                            employeeText = form["SearchTerm"];
                            break;
                        case "DepartmentText":
                            departmentText = form["SearchTerm"];
                            break;
                        case "SubDepartmentText":
                            subdepartmentText = form["SearchTerm"];
                            break;
                    }

                    var response = await client.GetAsync(
                        $"api/search?employeetext={employeeText}&departmenttext={departmentText}&subdepartmenttext={subdepartmentText}");

                    if (response.IsSuccessStatusCode)
                    {
                        var empResponse = response.Content.ReadAsStringAsync().Result;
                        employees = JsonConvert.DeserializeObject<List<EmployeeSearch>>(empResponse);
                    }

                    return View(employees);
                }
            }
                 
            return View();
        }
         
         
    }
}
