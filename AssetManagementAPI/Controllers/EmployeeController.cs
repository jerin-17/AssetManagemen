using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpPost]
        
        public IActionResult Create(EmployeeDTO employee)
        {
            try
            {
                _employeeService.CreateEmployee(employee);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateBatch")]

        public IActionResult CreateBatch(List<EmployeeDTO> employees)
        {
            try
            {
               List<int> employeeIds = _employeeService.CreateEmployeeBatch(employees);
                return Ok(employeeIds);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
