using EmailSenderWebService.Data;
using EmailSenderWebService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderWebService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    [HttpGet("group")]
    public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetEmployees(int id)
    {
        return Ok(await _employeeRepository.GetEmployees(id));
    }
}