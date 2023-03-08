using System.Linq;
using BlogAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly Context _context = new Context();
        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGetyId(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            var emp = _context.Find<Employee>(employee.Id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                _context.Update(emp);
                _context.SaveChanges();
                return Ok();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(employee);
                _context.SaveChanges();
                return Ok();
            }

        }


    }
}
