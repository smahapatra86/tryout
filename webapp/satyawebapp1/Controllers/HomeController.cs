using System;
using Microsoft.AspNetCore.Mvc;
using satyawebapp1.Database;
using Microsoft.Extensions.Configuration;

namespace satyawebapp1.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDb _employeeDb;
        IConfiguration _configuration;
        public HomeController(EmployeeDb employeeDb, IConfiguration configuration)
        {
            _employeeDb = employeeDb;
            _configuration = configuration;
        }
        [Route("home/index")]
        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return Ok($"Environment variable Default Connection {connectionString}");
        }
        [HttpGet("home/employees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employeeDb.Employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}