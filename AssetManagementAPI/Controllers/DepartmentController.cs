using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService deparmentService)
        {
            this._departmentService = deparmentService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
           return Ok(_departmentService.GetDepartments());
        }

        [HttpPost]

        public IActionResult CreateDepartment(DepartmentDTO department)
        {
            try
            {
                int id = _departmentService.CreateDepartment(department);
                return Ok(id);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
