
using CrudAPI.Domain.Infrastructure.Service;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace CrudAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {


        private readonly IEmployeeService _employeeService;


        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("test")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesTest()
        {
            return Ok(await _employeeService.GetEmployeesTest());
        }


        [HttpGet]
        public async Task<ActionResult<List<EmployeeViewModel>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee(int id)
        {
            EmployeeViewModel? EmployeeView = await _employeeService.GetEmployee(id);
            if (EmployeeView == null)
            {
                return NotFound("No employee with such ID");
            }

            return Ok(EmployeeView);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            bool Deleted = await _employeeService.DeleteEmployee(id);
            if (Deleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound("No employee with such ID");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeUpdateReq request)
        {
            // Update the employee with the specified ID using the provided data

            bool WasUpdated = await _employeeService.UpdateEmployee(id, request);
            if (WasUpdated)
            {
                return NoContent();

            }
            return NotFound("No employee with such ID");

        }


        [HttpPost]
        public async Task<ActionResult> AddEmployeeAsync(EmployeeUpdateReq emp)
        {
            // Add the new employee using the provided data
            if (await _employeeService.AddEmployee(emp))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AssignProjectToEmployee/{employeeId}/{projectId}")]
        public async Task<ActionResult> AddProjectToEmployee(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq)
        {
            bool WasAdded = await _employeeService.AddProjectToEmployee(employeeId, projectId, projectIntoEmployeeInsertReq);
            if (WasAdded)
            {
                return NoContent();
            }
            return BadRequest();

        }


        [HttpDelete("RemoveEmployeeFromProject/{employeeId}/{projectId}")]
        public async Task<ActionResult> DeleteEmployeeFromProject(int employeeId, int projectId)
        {
            bool WasDeleted = await _employeeService.DeleteEmployeeFromProject(employeeId, projectId);
            if (WasDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("EditEmployeesAssigmentDetailsInProject/{employeeId}/{projectId}")]
        public async Task<ActionResult> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq req)
        {
            bool WasUpdated = await _employeeService.EditEmployeesAssigmentDetailsInProject(employeeId, projectId, req);
            if (WasUpdated)
            {
                return NoContent();
            }
            return NotFound("Wrong ID");
        }

        [HttpGet("IsSuperviser/{superviserId}/{empId}")]
        public async Task<string> IsSubordinateOf(int superviserId, int empId)
        {
            return await _employeeService.IsSubordinateOf(superviserId, empId);
          
        }


    }
}
