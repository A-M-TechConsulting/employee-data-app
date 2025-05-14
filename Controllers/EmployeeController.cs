using Microsoft.AspNetCore.Mvc;
using EmployeeDataApp;
using System.Linq;
using Microsoft.Extensions.FileProviders;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Employees.ToLIst());

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(_context.Employees.Find(id))

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeID }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        var existingEmployee = _context.Employees.Find(id);
        if (existingEmployee == null) return NotFound();

        _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null) return NotFound();

        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return NoContent();
    }
}


