using DACKSearch.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DACKSearch.Domain.Requests;
using DACKSearch.Domain.Services;

namespace DACKSearch.API.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IEmployeeSearchService _employeeService;

        public SearchController(IEmployeeSearchService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeSearch(string employeeText, string departmentText, string subDepartmentText)
        {
            var result = await _employeeService.EmployeeSearch(new EmployeeSearchRequest()
            {
                DepartmentText = departmentText,
                EmployeeText = employeeText,
                SubDepartmentText = subDepartmentText
            });
            return Ok(result);
        }
    }
}
