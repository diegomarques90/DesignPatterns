using DesignPatterns.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        [HttpGet("get-expenses")]
        public IActionResult GetExpenses()
        {
            var director = new ManagerComposite("Director", "Director", 100000);
            director.Add(new Employee("Collaborator 1", "Developer", 300));
            director.Add(new Employee("Collaborator 2", "Developer", 300));

            var manager = new ManagerComposite("Manager", "Manager", 15000);
            manager.Add(new Employee("Collaborator 3", "Data Analyst", 300));
            manager.Add(new Employee("Collaborator 4", "Data Analyst", 300));

            director.Add(manager);

            return Ok(new
            {
                expensesDirector = director.GetExpenses(),
                expensesManager = manager.GetExpenses()
            });
        }
    }
}
