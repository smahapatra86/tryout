using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using satyawebapp1.Database;
using satyawebapp1.Models;

namespace satyawebapp1.Controllers
{
    [Route("employees")]
    public class EmployeeController : Controller
    {
        EmployeeDb _employeeDb;
        public EmployeeController(EmployeeDb employeeDb)
        {
            _employeeDb = employeeDb;
        }
        [HttpPost]
        public IActionResult CreateEmployee([Required][FromBody] Employee employee)
        {
            if (employee != null)
            {
                _employeeDb.Employees.Add(new Employee { Name = employee.Name });
                _employeeDb.SaveChanges();
                return Ok("Employee created");
            }
            else
            {
                return UnprocessableEntity("Not a proper input");
            }

        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeDb.Employees);
        }
    }
}